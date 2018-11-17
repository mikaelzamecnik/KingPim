import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExportService {

  private headers: HttpHeaders;
  private accessPointUrl = 'http://localhost:65436/files';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }
  export() {
    return this.http.get(this.accessPointUrl,
        {responseType: 'blob'});
}

}

