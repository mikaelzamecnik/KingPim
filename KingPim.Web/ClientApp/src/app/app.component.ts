import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './_models';
import { AuthenticationService } from './_services';


@Component({
  selector: 'app',
  template:
 `
  <router-outlet></router-outlet>
<alert></alert>`
})
export class AppComponent {
  currentUser: User;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  get isAdmin() {
    return this.currentUser && this.currentUser.userRoleId === 1;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
