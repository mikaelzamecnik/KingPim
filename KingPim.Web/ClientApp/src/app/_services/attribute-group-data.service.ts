import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AttributeGroup } from '../_models';

@Injectable()
export class AttributeGroupDataService {
  private headers: HttpHeaders;
  private accessPointUrl = 'pim/Category/SubCategory/AttributeGroup';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  getAttributeGroups(): Observable<AttributeGroup[]> {
    return this
      .http.get<AttributeGroup[]>(`${this.accessPointUrl}`);
  }
  getAttributeGroup(id) {
    return this
      .http
      .get(`${this.accessPointUrl}/${id}`);
  }
  addAttributeGroup(name, description, subCategoryId) {
    const obj = {
      name: name,
      subCategoryId: subCategoryId,
      description: description
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
