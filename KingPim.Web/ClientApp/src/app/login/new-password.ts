import { Component, OnInit } from '@angular/core';
import { AlertService, AuthenticationService, UserService } from '../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { Mustmatch } from '../../app/_helpers/mustmatch';

@Component({ templateUrl: 'new-password.html' })
export class NewPassword implements OnInit {
  user: any = {};
  registerForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService
  ) { this.createForm(); }

  createForm() {
    this.registerForm = this.formBuilder.group({
      id: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      userRoleId: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
        validator: Mustmatch('password', 'confirmPassword')
      });
    console.log(this.registerForm);
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.userService.getById(params['id']).subscribe(res => {
        this.user = res;
      });
    });
  }
  updateUser(firstName, lastName, username, email,
    userRoleId, password, confirmPassword) {
    this.route.params.subscribe(params => {
      this.userService.update(firstName, lastName, username, email,
        userRoleId, password, confirmPassword, params['id']);
      this.router.navigate(['/']);
    });
  }

  }
