import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class SubCategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category/SubCategory';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getSubCategories() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addSubCategory(subcategoryName, categoryId) {
    const obj = {
      subcategoryName: subcategoryName,
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
  updateSubCategory(subcategoryName, id) {

    const obj = {
      subcategoryName: subcategoryName
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
