import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Category } from '../_models';

@Injectable({ providedIn: 'root' })
export class CategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl:string = 'pim/Category/';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  public GetCategories() {
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }

  public GetCategoryId(payload) {
    return this.http.get(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public AddCategory(payload: Category) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }
  public RemoveCategory(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public UpdateCategory(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }

}
