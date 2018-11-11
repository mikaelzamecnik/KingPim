import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../_models';
import { AuthenticationService } from '../_services';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  currentUser: User;
  isLoggedIn$: Observable<boolean>;
  isExpanded = false;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService
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
}
