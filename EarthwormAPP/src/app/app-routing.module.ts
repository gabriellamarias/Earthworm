import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GardenComponent } from './garden/garden.component';
import { GardenerComponent } from './gardener/gardener.component';
import { PlantListComponent } from './plant-list/plant-list.component';
import { PlantPageComponent } from './plant-page/plant-page.component';

const routes: Routes = [
  { path: "garden", component: GardenComponent},
  { path: "gardener", component: GardenerComponent},
  { path: "plant/:name", component: PlantPageComponent},
  { path: "plant-list", component: PlantListComponent},
  { path: "", redirectTo: "/plant-list", pathMatch: "prefix"}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
