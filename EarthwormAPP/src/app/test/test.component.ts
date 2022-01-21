import { Component, OnInit } from '@angular/core';
import { Plant } from '../models/plant';
import { PlantApiService } from '../services/plant-api.service';


@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  plants: Plant[] = []

  constructor(
    private plantSVC: PlantApiService
  ) { }

  ngOnInit(): void {
    this.addDefaultPlants();
  }
addDefaultPlants() {
  this.plantSVC.getPlants().subscribe((plants) => {
    console.log("[INFO]")
      console.log(plants);
      this.plants = plants
  })
}

}
