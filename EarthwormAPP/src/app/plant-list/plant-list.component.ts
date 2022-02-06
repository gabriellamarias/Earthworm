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
  plants: Plant[] = [];
  plantName: string = "";
  filteredPlants: Plant[] = [];
  filtered: boolean = false;

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
        this.filteredPlants = plants
    })}
  

  getSearchedPlant() {
    this.plantSVC.getSearchedPlant(this.plantName).subscribe((plants) => {
      this.filteredPlants = plants;
      this.filtered = true;

    })}

    resetPlants() {
      this.filtered = false;
    }

    perennialPlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (plants[i].perennial){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
  }
    nonPerennialPlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (!plants[i].perennial){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
  }




    fullSunPlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (plants[i].openfarm_data.attributes.sun_requirements == 'Full Sun'){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
    }

    partSunPlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (plants[i].openfarm_data.attributes.sun_requirements == 'Partial Sun'){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
    }

partShadePlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (plants[i].openfarm_data.attributes.sun_requirements == 'Partial Shade'){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
    }

    fullShadePlants() {
      var filteredPlants: Plant[] = [];
      var plants = this.plants;
      for (var i = 0; i< plants.length; i++) {
        if (plants[i].openfarm_data.attributes.sun_requirements == 'Full Shade'){
             filteredPlants.push(plants[i]);
      }
    }
    this.filteredPlants = filteredPlants;
    this.filtered = true;
    }

  }

