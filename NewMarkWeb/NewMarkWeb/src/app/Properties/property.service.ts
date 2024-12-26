import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Property } from './property/Property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  constructor(private http: HttpClient) { }

  getProperties() {

    return this.http.get<Property[]>('https://localhost:7255/api/Properties');
  }
}
