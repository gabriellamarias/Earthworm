import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';

@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})
export class GardenComponent implements OnInit {
  gardens: Garden[] = []

  constructor(
    private gardenSVC: GardenApiService
  ) { }

  ngOnInit(): void {
    this.addDefaultGardens();
  }

  addDefaultGardens() {
    this.gardenSVC.getGardens().subscribe((gardens) => {
      console.log("[INFO]")
        console.log(gardens);
        this.gardens = gardens
    })

}}
