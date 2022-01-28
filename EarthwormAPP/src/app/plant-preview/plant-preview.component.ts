import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plant } from '../models/plant';

@Component({
  selector: 'app-plant-preview',
  templateUrl: './plant-preview.component.html',
  styleUrls: ['./plant-preview.component.css']
})
export class PlantPreviewComponent implements OnInit {
  @Input() content!: Plant;

  linkToPlant: string = `#`;

  constructor(
    private router: Router

  ) { }

  ngOnInit(): void {
    this.linkToPlant = `/plant/${this.content.name}`;

  }

}
