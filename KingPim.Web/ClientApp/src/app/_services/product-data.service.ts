import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../_models';

@Injectable()
export class ProductDataService {
  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/Product';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getProducts(): Observable<Product[]> {
    return this
      .http.get<Product[]>(`${this.accessPointUrl}`);
  }
  getProduct(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }

  addProduct(name, description, subCategoryId, editedBy) {
    const obj = {
      name: name,
      description: description,
      subCategoryId: subCategoryId,
      editedBy: editedBy
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
  updateProduct(name, description, subCategoryId, version, editedBy, id) {
    const obj = {
      name: name,
      description: description,
      subCategoryId: subCategoryId,
      version: version,
      editedBy: editedBy
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }
  updateProductStatus(productid, publishedStatus) {
    const obj = {
      publishedStatus: publishedStatus
    };
    this
      .http
      .put(`${this.accessPointUrl}/publish/${productid}`, obj)
      .subscribe(res => console.log('Done'));
  }
}
