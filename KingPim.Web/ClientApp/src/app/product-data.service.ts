import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ProductDataService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'pim/Category/SubCategory/Product';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  public GetProducts() {
    return this.http.get(this.accessPointUrl, { headers: this.headers });
  }

  public GetProductId(payload) {
    return this.http.get(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public AddProduct(payload) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }
  public RemoveProduct(payload) {
    return this.http.delete(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }
  public UpdateProduct(payload) {
    return this.http.put(this.accessPointUrl + '/' + payload.Id, { headers: this.headers });
  }

}
