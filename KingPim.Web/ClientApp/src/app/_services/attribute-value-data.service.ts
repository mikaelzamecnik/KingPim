import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class AttributeValueDataService {

  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/AttributeGroup/ProductAttribute/ProductAttributeValue';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getAttributes() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addAttributevalue(productId, productattributeId, value) {
    const obj = {
      productId: productId,
      productattributeId: productattributeId,
      value: value
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
  deleteAttributevalue(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editAttributevalue(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateAttributevalue(name, id) {

    const obj = {
      name: name
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }
}
