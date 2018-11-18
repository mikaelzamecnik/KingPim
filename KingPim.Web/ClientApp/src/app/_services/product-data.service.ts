import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { isBoolean } from 'util';

@Injectable()
export class ProductDataService {
  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/Product';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getProducts() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addProduct(name, description, subCategoryId) {
    const obj = {
      name: name,
      description: description,
      subCategoryId: subCategoryId
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done'));
  }
  deleteProduct(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editProduct(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateProduct(name, description, subcategoryId, publishedStatus, id) {
    const obj = {
      name: name,
      description: description,
      subcategoryId: subcategoryId,
      publishedStatus: publishedStatus
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }
  //updateProductStatus(publishedStatus) {
  //  const obj = {
  //    publishedStatus : publishedStatus
  //  };
  //  this
  //    .http
  //    .put(`${this.accessPointUrl}/`, obj)
  //    .subscribe(res => console.log('Done'));
  //}

}
