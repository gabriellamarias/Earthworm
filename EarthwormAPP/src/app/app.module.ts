import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';
import { PlantListComponent } from './plant-list/plant-list.component';
import { PlantPageComponent } from './plant-page/plant-page.component';
import { GardenComponent } from './garden/garden.component';
import { GardenerComponent } from './gardener/gardener.component';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    PlantListComponent,
    PlantPageComponent,
    GardenComponent,
    GardenerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
