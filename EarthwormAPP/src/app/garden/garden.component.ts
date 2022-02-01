import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})
export class GardenComponent implements OnInit {
  gardens: Garden[] = []
  username: string = '';
  submitted = false;
  linkToGarden: string = `#`;

  constructor(
    private gardenSVC: GardenApiService,
    private router: Router
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

  }

  addUserGardens(username: string) {
    username = this.username
    this.submitted = true;
    this.gardenSVC.getUserGardens(username).subscribe((gardens) => {
      console.log("[INFO]")
        console.log(gardens);
        this.gardens = gardens
    })

  }

  goToGarden(gardenName: string) {
    this.linkToGarden = `/garden/${gardenName}`;
  }

}
