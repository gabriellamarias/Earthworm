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


  deleteGarden(id: number): Observable<unknown> {
    return this.httpClient.delete(`https://localhost:44311/api/garden?ID=${ id }`)
  }


}