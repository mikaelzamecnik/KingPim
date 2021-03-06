import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class AttributeDataService {

  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/AttributeGroup/ProductAttribute';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getAttributes() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addAttribute(attributegroupId, name, description, type, attributeOptionListId, attributeOptionList) {
    const obj = {
      attributegroupId:attributegroupId,
      name: name,
      description: description,
      type: type,
      attributeOptionListId: attributeOptionListId,
      attributeOptionList: attributeOptionList

    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
  deleteAttribute(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editAttribute(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateAttribute(name, id) {

    const obj = {
      name: name
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }
}
