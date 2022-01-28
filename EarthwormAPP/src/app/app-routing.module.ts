import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GardenComponent } from './garden/garden.component';
import { GardenerComponent } from './gardener/gardener.component';
import { PlantPageComponent } from './plant-page/plant-page.component';

const routes: Routes = [
  { path: "garden", component: GardenComponent},
  { path: "gardener", component: GardenerComponent},
  { path: "plant", component: PlantPageComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
