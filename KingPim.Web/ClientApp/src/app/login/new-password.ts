import { Component, OnInit } from '@angular/core';
import { AlertService, AuthenticationService, UserService } from '../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { Mustmatch } from '../../app/_helpers/mustmatch';

@Component({ templateUrl: 'new-password.html' })
export class NewPassword implements OnInit {
  registerForm: FormGroup;
  user: any = {};
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private alertService: AlertService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.createForm();
  }


  createForm() {
    this.registerForm = this.formBuilder.group({
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
      this.userService.getById(params['userId']).subscribe(res => {
        this.user = res;
        console.log(res);
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
