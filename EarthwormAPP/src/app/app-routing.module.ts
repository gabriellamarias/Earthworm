import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GardenComponent } from './garden/garden.component';
import { GardenerComponent } from './gardener/gardener.component';
import { PlantListComponent } from './plant-list/plant-list.component';
import { PlantPageComponent } from './plant-page/plant-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CreateGardenComponent } from './create-garden/create-garden.component';
import { GardenPageComponent } from './garden-page/garden-page.component';
import { GardenCenterComponent } from './garden-center/garden-center.component';

const routes: Routes = [
  { path: "garden-center", component: GardenCenterComponent},
  { path: "search-garden", component: GardenComponent},
  { path: "create-garden", component: CreateGardenComponent},
  { path: "gardener", component: GardenerComponent},
  { path: "garden/:name", component: GardenPageComponent},
  { path: "plant/:name", component: PlantPageComponent},
  { path: "plant-list", component: PlantListComponent},
  {path: "home", component: HomePageComponent},
  { path: "", redirectTo: "home", pathMatch: "prefix"}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
