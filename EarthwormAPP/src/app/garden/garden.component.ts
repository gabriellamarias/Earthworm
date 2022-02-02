import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';
import { Router } from '@angular/router';
import { GardenerApiService } from '../services/gardener-api.service';

@Component({
  selector: 'app-garden',
  templateUrl: './garden.component.html',
  styleUrls: ['./garden.component.css']
})
export class GardenComponent implements OnInit {
  gardens: Garden[] = []
  usernames: string[] = [];
  username: string = "";
  submitted = false;
  linkToGarden: string = `#`;

  gardenString: string[] = [];

  constructor(
    private gardenSVC: GardenApiService,
    private gardenerAPISvc: GardenerApiService
  ) { }

  ngOnInit(): void {
    this.gardenerAPISvc.getGardener().subscribe((usernames) => {
      for(var i = 0; i < usernames.length; i++)
      {
        this.usernames.push(usernames[i].username)
      }
    })
  }

  addUserGardens(username: string) {
    username = this.username;
    this.submitted = true;
    this.gardenSVC.getUserGardens(username).subscribe((gardenString) => {
      console.log("[INFO]")
      console.log(gardenString);
      this.gardenString = gardenString;
    })
  }

  goToGarden(gardenName: string) {
    this.linkToGarden = `/garden/${gardenName}/${this.username}`;
  }

}
