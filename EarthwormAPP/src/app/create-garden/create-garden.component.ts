import { Component, OnInit } from '@angular/core';
import { Garden } from '../models/garden';
import { GardenApiService } from '../services/garden-api.service';
import { createGarden } from '../models/creategarden';
import { GardenerApiService } from '../services/gardener-api.service';

@Component({
  selector: 'app-create-garden',
  templateUrl: './create-garden.component.html',
  styleUrls: ['./create-garden.component.css']
})
export class CreateGardenComponent implements OnInit {
  model = new createGarden('','','');
  submitted = false;
  createdGarden = {} as Garden;
  gardens: Garden[] = [];
  usernames: string[] = [];
  username: string = "";

  constructor(
    private gardenAPIsvc: GardenApiService,
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

  newGarden() {
    this.model = new createGarden('','', '')
    console.log(this.model)
  }

  onSubmit() {
    this.submitted = true;
    this.createdGarden = new Garden(this.model.gardenName,'', this.username);
    console.log(this.createdGarden)
    console.dir(this.createdGarden)
    this.gardenAPIsvc.createGarden(this.createdGarden).subscribe();
  }

}
