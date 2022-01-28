import { Component, OnInit } from '@angular/core';
import { Gardener } from '../models/gardener';
import { GardenerApiService } from '../services/gardener-api.service';

@Component({
  selector: 'app-gardener',
  templateUrl: './gardener.component.html',
  styleUrls: ['./gardener.component.css']
})
export class GardenerComponent implements OnInit {
  gardener: Gardener[] = []

  constructor(
    private gardenerSVC: GardenerApiService
  ) { }

  ngOnInit(): void {
    this.addDefaultGardener();
  }

  addDefaultGardener() {
    this.gardenerSVC.getGardener().subscribe((gardener) => {
      console.log("[INFO]")
        console.log(gardener);
        this.gardener = gardener
    })
  
  }}
