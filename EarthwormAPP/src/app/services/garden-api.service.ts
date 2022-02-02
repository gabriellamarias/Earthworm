import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs'
import { Garden } from '../models/garden';



@Injectable({
  providedIn: 'root'
})
export class GardenApiService {

  constructor(
    private httpClient: HttpClient

  ) { }

  getGardens(): Observable<Garden[]> {
    return this.httpClient.get<Garden[]>("https://localhost:44311/api/garden")
  }

  createGarden(garden: Garden): Observable<Garden> {
    return this.httpClient.post<Garden>("https://localhost:44311/api/garden", garden)
  }

  deleteGarden(gardenName: string): Observable<unknown> {
    return this.httpClient.delete(`https://localhost:44311/api/garden?name=${ gardenName }`)
  }

  getUserGardens(username: string): Observable<Garden[]> {
    return this.httpClient.get<Garden[]>(`https://localhost:44311/api/garden/ViewGardens?userinput=${ username }`)
  }

  getUserGardens2(username: string): Observable<string[]> {
    return this.httpClient.get<string[]>(`https://localhost:44311/api/garden/ViewGardens?userinput=${ username }`)
  }

  getFullGarden(gardenName: string): Observable<string[]> {
    return this.httpClient.get<string[]>(`https://localhost:44311/api/garden/getgarden?name=${ gardenName}`)
  }

  updateGarden( gardenName: string, oldGardenName: string): Observable<any> {
    return this.httpClient.put(`https://localhost:44311/api/garden?name=${ gardenName }`, oldGardenName)
}


}