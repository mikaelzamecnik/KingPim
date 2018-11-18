import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExportService {


  private headers: HttpHeaders;
  private accessPointUrl = 'http://localhost:65436/pim/export/GetProductsToJson';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/octet-stream' });

  }
  //Get the json file as blob
  public getProductsToJson() {
    return this.http.get(this.accessPointUrl, {
      responseType: 'blob', headers: this.headers
    });
}

}

