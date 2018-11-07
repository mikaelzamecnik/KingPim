import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class CategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getCategories() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addCategory(CategoryName) {
    const obj = {
      CategoryName: CategoryName
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done'));
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
  updateCategory(categoryName, id) {

    const obj = {
      categoryName: categoryName
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
