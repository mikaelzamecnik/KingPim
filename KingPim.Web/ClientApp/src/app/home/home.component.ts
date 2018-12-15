import { Component } from '@angular/core';
import { AuthenticationService } from '../_services';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

@Component({selector: 'app-home', templateUrl: './home.component.html'})
export class HomeComponent {
  userRoleAdmin: Boolean;
  userRolePublisher: Boolean;
  userRoleEditor: Boolean;


  constructor(
    private authenticationService: AuthenticationService
  ) { }


  // Testing out role based auth
  canRoleActivate() {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser.userRoleId === 1) {

      this.userRoleAdmin === true;
      this.userRolePublisher === true;
      this.userRoleEditor === true;

      return currentUser.userRoleId;
    }
    if (currentUser.userRoleId === 2) {

      this.userRoleAdmin === false;
      this.userRolePublisher === true;
      this.userRoleEditor === true;
      return currentUser.userRoleId;

    }
    if (currentUser.userRoleId === 3) {

      this.userRoleAdmin === false;
      this.userRolePublisher === false;
      this.userRoleEditor === true;
      return currentUser.userRoleId;
    }
  }

}
