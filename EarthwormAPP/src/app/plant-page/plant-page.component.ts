import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Garden } from '../models/garden';
import { Plant } from '../models/plant';
import { GardenApiService } from '../services/garden-api.service';
import { PlantApiService } from '../services/plant-api.service';

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
id: number = 0;
gardenName: string = "";
plantName: string = "";
  constructor(
    private plantAPISvc: PlantApiService,
    private gardenAPISvc: GardenApiService,
    private route: ActivatedRoute,
    private router: Router,
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

}

// addToGarden() {
//   let garden = new Garden(this.gardenName, this.plant.name)
//   this.gardenAPISvc.createGarden(garden).subscribe((garden) => {})
// }



}
