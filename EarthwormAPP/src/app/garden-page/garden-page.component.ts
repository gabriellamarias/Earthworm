import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';

@Component({
  selector: 'app-garden-page',
  templateUrl: './garden-page.component.html',
  styleUrls: ['./garden-page.component.css']
})
export class GardenPageComponent implements OnInit {
  
  selectedGarden = {} as Event;
  gardenId: Number = 0;
  successful = false;
  linkToUpdate: string = '#';


  constructor() { }

  ngOnInit(): void {
  }

}
