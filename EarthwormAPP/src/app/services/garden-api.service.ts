import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs'
import { Garden } from '../models/garden';
import { gardenCRUD } from '../models/gardencrud';



@Injectable({
  providedIn: 'root'
})
export class GardenApiService {

  constructor(
    private httpClient: HttpClient

  ) { }

  getUserGardens(username: string): Observable<string[]> {
    return this.httpClient.get<string[]>(`https://localhost:44311/api/garden/viewgardens?userinput=${ username }`)
  }

  getAllGardenPlants(gardenName: string, username:string): Observable<any> {
    return this.httpClient.get<string[]>(`https://localhost:44311/api/garden/getgarden?gardenname=${ gardenName }&username=${ username }`)
  }

  createGarden(garden: Garden): Observable<Garden> {
    return this.httpClient.post<Garden>("https://localhost:44311/api/garden/addgarden", garden)
  }

  updateGarden( gardenName: string, garden:gardenCRUD): Observable<any> {
    return this.httpClient.put(`https://localhost:44311/api/garden/updategarden?gardenname=${ gardenName }`, garden)
  }

  deleteGarden(gardenName: string, garden: gardenCRUD): Observable<unknown> {
    return this.httpClient.put<gardenCRUD>(`https://localhost:44311/api/garden/deletegarden?gardenname=${ gardenName }`, garden)
  }
  
  

}



