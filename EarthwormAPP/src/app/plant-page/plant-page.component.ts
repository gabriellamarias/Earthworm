import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Garden } from '../models/garden';
import { Plant } from '../models/plant';
import { GardenApiService } from '../services/garden-api.service';
import { PlantApiService } from '../services/plant-api.service';
import { GardenerApiService } from '../services/gardener-api.service';

@Component({
  selector: 'app-plant-page',
  templateUrl: './plant-page.component.html',
  styleUrls: ['./plant-page.component.css']
})
export class PlantPageComponent implements OnInit {
plant: Plant = {openfarm_data:{attributes: {description: "", row_spacing:0, spread:0, height: 0, sowing_method: "",
sun_requirements: "", growing_degree_days: 0, main_image_path: ""}}, name: "", en_wikipedia_url:"", perennial: "",
 median_lifespan: 0, median_days_to_first_harvest: 0, median_days_to_last_harvest: 0};

name: string = "";
gardenName: string = "";
gardenNames: string[] = [];
usernames: string[] = [];
username: string = "";
submitted = false;

  constructor(
    private plantAPISvc: PlantApiService,
    private gardenAPISvc: GardenApiService,
    private gardenerAPISvc: GardenerApiService,
    private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    const name = this.route.snapshot.paramMap.get('name');
    if(name) {
      this.name = name;
  }
  this.plantAPISvc.getPlants().subscribe((plants) => {
    for(var i = 0; i < plants.length; i++)
    {if (plants[i].name == this.name)
      {
        this.plant = plants[i]
      }
    
    }
    console.log(this.plant.name)
  })

  this.gardenerAPISvc.getGardener().subscribe((usernames) => {
    for(var i = 0; i < usernames.length; i++)
    {
      this.usernames.push(usernames[i].username)
    }
  })
}

addUserGardens2(username: string) {
  username = this.username;
  this.submitted = true;
  this.gardenAPISvc.getUserGardens2(username).subscribe((gardenString) => {
    console.log("[INFO]")
    console.log(gardenString);
    this.gardenNames = gardenString;
  })
}
addToGarden() {
  let garden = new Garden(this.gardenName, this.plant.name, this.username)
  this.gardenAPISvc.createGarden(garden).subscribe((garden) => {})
}



}
