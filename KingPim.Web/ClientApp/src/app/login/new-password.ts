import { Component, OnInit } from '@angular/core';
import { AlertService, AuthenticationService, UserService } from '../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, Params, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { Mustmatch } from '../../app/_helpers/mustmatch';


@Component({
  template: `
   <form [formGroup]="angForm" novalidate> Password:
<input type=text placeholder="Password" formControlName="password" #password />
Confirm Password:
<input type=text placeholder="Confirm Password" formControlName="confirmpassword" #confirmpassword />
<input type=text formControlName="firstname" #firstname [value]="user.firstName" />
<input type=text formControlName="lastname" #lastname [value]="user.lastName" />
<input type=text formControlName="username" #username [value]="user.username" />
<input type=text formControlName="email" #email [value]="user.email"/>
<input type=text formControlName="userRoleId" #userRoleId [value]="user.userRoleId" />
<button (click)="submit(password.value,
confirmpassword.value,
firstname.value,
lastname.value,
username.value,
email.value,
userRoleId.value
)">Reset</button></form>
  `
})
export class NewPassword implements OnInit {
  angForm: FormGroup;
  user: any = {};
  loading = false;
  submitted = false;

  constructor(
    private fb: FormBuilder,
    private us: UserService,
    private alertService: AlertService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.createForm();
  }


  createForm() {
    this.angForm = this.fb.group({
      id: 2,
      firstname: [''],
      lastname: [''],
      username: [''],
      email: [''],
      userRoleId: [''],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmpassword: ['', Validators.required]
    })
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.us.getById(params['userId']).subscribe(res => {
        this.user = res;
        console.log(res);
      });
    });


  }


  // convenience getter for easy access to form fields
  get f() { return this.angForm.controls; }
  submit() {
    this.submitted = true;
    this.loading = true;
    this.us.update(this.user.id, this.angForm.value)
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('Update successful', true);
          this.router.navigate(['/']);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });

  }
}
