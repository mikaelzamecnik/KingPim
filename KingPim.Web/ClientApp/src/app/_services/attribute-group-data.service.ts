import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AttributeGroupDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category/SubCategory/Ag';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getAttributeGroups() {
    return this
      .http.get(`${this.accessPointUrl}`);
  }

  addAttributeGroup(name) {
    const obj = {
      name: name
    };
    console.log(obj);
    this.http.post(`${this.accessPointUrl}/`, obj)
      .subscribe(res => console.log('Done', obj));
  }
  deleteAttributeGroup(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  editAttributeGroup(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  updateAttributeGroup(name, id) {

    const obj = {
      name: name
    };
    this
      .http
      .put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}
