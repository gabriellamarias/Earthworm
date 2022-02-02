import { Component, OnInit } from '@angular/core';
import { GardenApiService } from '../services/garden-api.service';
import { ActivatedRoute } from '@angular/router';
import { Plant } from '../models/plant';
import { PlantApiService } from '../services/plant-api.service';
import { gardenCRUD } from '../models/gardencrud';


@Component({
  selector: 'app-garden-page',
  templateUrl: './garden-page.component.html',
  styleUrls: ['./garden-page.component.css']
})
export class GardenPageComponent implements OnInit {
  name: string = "";
  gardenPlants: string[] = [];
  allPlants: Plant[] = [];
  userGarden : gardenCRUD = {username: '', gardenName: ''};
  username: string = "";
  deleted = false;
  updated = false;
  newname : string = "";

  // plant: Plant = {openfarm_data:{attributes: {description: "", row_spacing:0, spread:0, height: 0, sowing_method: "",
  // sun_requirements: "", growing_degree_days: 0, main_image_path: ""}}, name: "", en_wikipedia_url:"", perennial: "",
  // median_lifespan: 0, median_days_to_first_harvest: 0, median_days_to_last_harvest: 0};

  constructor(
    private gardenAPISvc: GardenApiService,
    private route: ActivatedRoute,
    private plantAPISvc: PlantApiService
  ) { }

  ngOnInit(): void {
    const name = this.route.snapshot.paramMap.get('name');
    if(name) {
      this.name = name;
    }

    const username = this.route.snapshot.paramMap.get('username');
    if(username){
      this.username = username;
    }

    this.gardenAPISvc.getAllGardenPlants(this.name, this.username).subscribe((plants) => {
      this.gardenPlants = plants
    })

    this.plantAPISvc.getPlants().subscribe((plants) => {
    for(var i = 0; i < plants.length; i++)
    { if (this.gardenPlants.includes(plants[i].name))
      {
        this.allPlants.push(plants[i])
      }
    }
  })
  this.userGarden = {gardenName:this.name, username: this.username}
  }

  deleteGarden(){
    this.deleted = true;
    this.gardenAPISvc.deleteGarden(this.name, this.userGarden).subscribe();
  }

  updateButton(){
    this.updated = true;
  }

  updateGarden(newname2: string){
    this.name = newname2;
    this.gardenAPISvc.updateGarden(this.name, this.userGarden).subscribe();
    this.updated = false;
    this.deleted = false;
    
  }

  removePant(){

  }

}
