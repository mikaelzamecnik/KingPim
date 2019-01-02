import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class AttributelistDataService {

  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/AttributeGroup/ProductAttribute';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  // Attribute list
  getAttributeLists() {
    return this
      .http.get(`${this.accessPointUrl}/getattolist/`);
  }

  addAttributeList(attributeGroupId, name) {
    const obj = {
      name: name,
      attributeGroupId: attributeGroupId

    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/postattolist/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
  // AttributeList Values
  getAttributeListValues() {
    return this
      .http.get(`${this.accessPointUrl}/getattovaluelist/`);
  }

  getAttributeListValue(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/getattovaluelist/${id}`);
  }

  addAttributeListValue(attributeOptionListId, listValue) {
    const obj = {
      listValue: listValue,
      attributeOptionListId: attributeOptionListId

    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/postattovaluelist/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
}
