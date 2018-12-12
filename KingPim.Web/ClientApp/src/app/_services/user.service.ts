import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models';

@Injectable()
export class UserService {

  private headers: HttpHeaders;
  private accessPointUrl = 'users';


  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`${this.accessPointUrl}`);
  }

  getById(id) {
    return this.http.get(`${this.accessPointUrl}/${id}`);
  }

  register(user: User) {
    return this.http.post(`/users/register`, user);
  }

  update(firstName, lastName, username, email,
    userRoleId, password, confirmPassword, id) {
    const obj = {
      firstName: firstName,
      lastName: lastName,
      username: username,
      email: email,
      userRoleId: userRoleId,
      password: password,
      confirmPassword: confirmPassword
    };
    console.log(obj);
    this.http.put(`${this.accessPointUrl}/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

  delete(id) {
    return this
      .http
      .delete(`${this.accessPointUrl}/${id}`);
  }
  forgotPassword(user: User) {
    return this.http.post(`/users/forgotpassword`, user);
  }
}
