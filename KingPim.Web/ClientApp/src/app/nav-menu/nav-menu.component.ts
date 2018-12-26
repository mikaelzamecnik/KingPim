import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../_models';
import { AuthenticationService, UserService } from '../_services';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  currentUser: User;
  isLoggedIn$: Observable<boolean>;
  isExpanded = false;
  users: User[] = [];

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private userService: UserService
  ) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }
  ngOnInit() {
    this.isLoggedIn$ = this.authenticationService.isLoggedIn;
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  getUser(id: number) {
    this.userService.getById(id).pipe(first()).subscribe(() => {

    });
  }

  // UserRole
  get isAdmin() {
    return this.currentUser && this.currentUser.userRoleId === 1;
  }
  get isPublisher() {
    return this.currentUser && this.currentUser.userRoleId === 2;
  }
  get isEditor() {
    return this.currentUser && this.currentUser.userRoleId === 3;
  }
}
