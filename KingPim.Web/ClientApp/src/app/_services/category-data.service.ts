import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getCategories() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addCategory(name) {
    const obj = {
      name: name
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
  deleteCategory(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editCategory(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateCategory(name, id) {

    const obj = {
      name: name
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
