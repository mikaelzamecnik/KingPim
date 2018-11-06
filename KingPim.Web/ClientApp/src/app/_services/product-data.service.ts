import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ProductDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category/SubCategory/Product';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getProducts() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addProduct(productName) {
    const obj = {
      productName: productName
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
  updateProduct(productName, productID) {

    const obj = {
      productName: productName
    };
    this
      .http
      .post(`${this.accessPointUrl}/${productID}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
