import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SubCategory } from '../_models';

@Injectable()
export class SubCategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getSubCategories(): Observable<SubCategory[]> {
    return this
      .http.get<SubCategory[]>(`${this.accessPointUrl}`);
  }

  addSubCategory(name, categoryId) {
    const obj = {
      name: name,
      categoryId: categoryId
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done'));
  }
  deleteSubCategory(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editSubCategory(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateSubCategory(name, id) {

    const obj = {
      name: name
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
