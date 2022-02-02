import { Component, OnInit } from '@angular/core';
import { Gardener } from '../models/gardener';
import { GardenerApiService } from '../services/gardener-api.service';

@Component({
  selector: 'app-gardener',
  templateUrl: './gardener.component.html',
  styleUrls: ['./gardener.component.css']
})
export class GardenerComponent implements OnInit {
  username: string = "";
  gardener: Gardener = {username:"", gardenId: 2};
  submitted = false;

  constructor(
    private gardenerSVC: GardenerApiService
  ) { }

  ngOnInit(): void {}

  onSubmit(){
    this.submitted = true;
    this.gardener = {username:this.username, gardenId: 2 };
    this.gardenerSVC.createGardener(this.gardener).subscribe();
    }

  }


  
