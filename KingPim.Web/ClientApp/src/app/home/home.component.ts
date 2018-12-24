import { Component } from '@angular/core';
import { AuthenticationService } from '../_services';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { User } from '../_models';

@Component({selector: 'app-home', templateUrl: './home.component.html'})
export class HomeComponent {
  currentUser: User;


  constructor(
    private authenticationService: AuthenticationService
  ) {

    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.userRoleId === 1;
  }

}
