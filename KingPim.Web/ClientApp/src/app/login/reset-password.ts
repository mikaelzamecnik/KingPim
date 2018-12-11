import { Component } from '@angular/core';
import { AlertService, AuthenticationService, UserService } from '../_services';
import { User } from '../_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs/operators';


@Component({
  template: `
   <form [formGroup]="angForm" novalidate> UserName:
<input type=text placeholder="UserName" formControlName="username" #username />
Email:
<input type=text placeholder="Email" formControlName="email" #email />
<button (click)="sendLink(username.value)">Send</button></form>
  `
})
export class ResetPassword {
  angForm: FormGroup;

  constructor(private fb: FormBuilder, private us: UserService, private alertService: AlertService, private router: Router,) {
    this.createForm();
  }


  createForm() {
    this.angForm = this.fb.group({
      email: ['', Validators.required],
      username: ['', Validators.required]
    });

  }



  sendLink() {
    this.us.forgotPassword(this.angForm.value)
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('Registration successful', true);
          this.router.navigate(['/']);
        },
        error => {
          this.alertService.error(error);
        });
    console.log(this.angForm);
  }

}
