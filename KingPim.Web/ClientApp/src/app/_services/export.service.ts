import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExportService {


  private headers: HttpHeaders;
  private accessPointUrl = 'pim/export';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/octet-stream' });

  }
  // Get the json file as blob
  public getProductsToJson() {
    return this.http.get(this.accessPointUrl + '/Products', {
      responseType: 'blob', headers: this.headers
    });
}
public getCategoriesToJson() {
  return this.http.get(this.accessPointUrl + '/Categories', {
    responseType: 'blob', headers: this.headers
  });
}
public getSubCategoriesToJson() {
  return this.http.get(this.accessPointUrl + '/SubCategories', {
    responseType: 'blob', headers: this.headers
  });
}

}

