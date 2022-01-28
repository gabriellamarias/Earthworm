import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from 'rxjs'
import { Gardener } from '../models/gardener';



@Injectable({
  providedIn: 'root'
})
export class GardenerApiService {

  constructor(
    private httpClient: HttpClient

  ) { }

  getGardener(): Observable<Gardener[]> {
    return this.httpClient.get<Gardener[]>("https://localhost:44311/api/gardener")


  }


}