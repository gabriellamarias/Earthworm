import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';
import { createGarden } from '../models/creategarden';

@Component({
  selector: 'app-create-garden',
  templateUrl: './create-garden.component.html',
  styleUrls: ['./create-garden.component.css']
})
export class CreateGardenComponent implements OnInit {
  model = new createGarden('','');
  submitted = false;
  createdGarden = {} as Garden;
  gardens: Garden[] = [];

  constructor(
    private gardenAPIsvc: GardenApiService
  ) { }

  ngOnInit(): void {
  }

  newGarden() {
    this.model = new createGarden('','')
    console.log(this.model)
  }

  onSubmit() {
    this.submitted = true;
    this.createdGarden = new Garden(this.model.gardenName,'');
    console.log(this.createdGarden)
    console.dir(this.createdGarden)
    this.gardenAPIsvc.createGarden(this.createdGarden).subscribe();
  }

}
