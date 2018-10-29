import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class SubCategoryDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category/SubCategory/';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  public GetSubCategories() {
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }

  public GetSubCategoryId(payload) {
    return this.http.get(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public AddSubCategory(payload) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }
  public RemoveSubCategory(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public UpdateSubCategory(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }

}
