import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';
@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient) {}

  url = 'https://localhost:44350/api';

  // This method will return an observable of categories from the Web API
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.url}/categories`);
  }
}
