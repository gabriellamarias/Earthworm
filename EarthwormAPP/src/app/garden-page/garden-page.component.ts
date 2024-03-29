import { Component, OnInit } from '@angular/core';
import { GardenApiService } from '../services/garden-api.service';
import { ActivatedRoute } from '@angular/router';
import { Plant } from '../models/plant';
import { PlantApiService } from '../services/plant-api.service';
import { gardenCRUD } from '../models/gardencrud';
import { ThisReceiver } from '@angular/compiler';


@Component({
  selector: 'app-garden-page',
  templateUrl: './garden-page.component.html',
  styleUrls: ['./garden-page.component.css']
})
export class GardenPageComponent implements OnInit {
  name: string = "";
  gardenPlants: string[] = [];
  allPlants: Plant[] = [];
  singlePlant: Plant  = {openfarm_data:{attributes: {description: "", row_spacing:0, spread:0, height: 0, sowing_method: "",
  sun_requirements: "", growing_degree_days: 0, main_image_path: ""}}, name: "", en_wikipedia_url:"", perennial: "",
   median_lifespan: 0, median_days_to_first_harvest: 0, median_days_to_last_harvest: 0};
  filteredPlants: Plant[] = [];
  userGarden : gardenCRUD = {username: '', gardenName: ''};
  username: string = "";
  deleted = false;
  updated = false;
  plantdeleted = false;
  newname : string = "";
  plantName: string = "";

  constructor(
    private gardenAPISvc: GardenApiService,
    private route: ActivatedRoute,
    private plantAPISvc: PlantApiService
  ) { 
    
  }

  ngOnInit(): void {
    const name = this.route.snapshot.paramMap.get('name');
    if(name) {
      this.name = name;
    }

    const username = this.route.snapshot.paramMap.get('username');
    if(username){
      this.username = username;
    }

    this.userGarden = {gardenName:this.name, username: this.username}

    // this.gardenAPISvc.getAllGardenPlants(this.name, this.username).subscribe((plants) => {
    //   this.gardenPlants = plants
    //   console.log('[gardenPlants]');
    //   console.log(plants);
    // })
    this.callAPI();
    //this.getSearchedPlant();

  //   this.plantAPISvc.getPlants().subscribe((plants) => {
  //   for(var i = 0; i < plants.length; i++)
  //   { if (this.gardenPlants.includes(plants[i].name))
  //     {
  //       this.allPlants.push(plants[i])
  //     }
  //   }
  // })
  }

//   getGardenByPlantName() {
//     for (var i = 0; i < this.gardenPlants.length; i++)
//     { 
//     }
//   }
  callAPI() {
    
    this.gardenAPISvc.getAllGardenPlants(this.name, this.username).subscribe((plants) => {
      this.gardenPlants = plants
      console.log('[gardenPlants]');
      console.log(plants);
      this.getSearchedPlant();
    })
  }
  getSearchedPlant() {
    console.log('hi');
    for (var i = 0; i < this.gardenPlants.length; i++)
   {
      this.plantAPISvc.getSinglePlant(this.gardenPlants[i]).subscribe((plant) => {
      this.singlePlant = plant;
     // console.log(this.singlePlant)
      console.log(this.singlePlant);
      this.allPlants.push(plant);
      // this.filtered = true;
      // this.notFound = false;
      
    }
    
    );
 }
}

  deleteGarden(){
    this.deleted = true;
    this.gardenAPISvc.deleteGarden(this.name, this.userGarden).subscribe();
  }

  updateButton(){
    this.updated = true;
  }

  updateGarden(newname2: string){
    this.newname = newname2;
    this.userGarden = {gardenName:this.newname, username: this.username}
    this.gardenAPISvc.updateGarden(this.name, this.userGarden).subscribe();
    this.name = newname2;   
    this.goBack();
  }

  reload(){
    window.location.reload();
  }

  goBack() {
    this.updated = false;
    this.deleted = false;
  }

  removePlant(plantname2: string){
    this.plantName = plantname2;
    console.log(this.plantName)
    this.gardenAPISvc.deletePlant(this.name, this.plantName, this.userGarden).subscribe();
    this.plantdeleted = true;
    this.reload();
  }

}
