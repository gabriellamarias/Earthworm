import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plant } from '../models/plant';
import { PlantApiService } from '../services/plant-api.service';

@Component({
  selector: 'app-plant-list',
  templateUrl: './plant-list.component.html',
  styleUrls: ['./plant-list.component.css']
})
export class PlantListComponent implements OnInit {
  plants: Plant[] = []
 

  constructor(
    private plantSVC: PlantApiService,
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

}}
