import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { Mustmatch } from '../../../_helpers';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService, AlertService } from '../../../_services';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../_models';

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html'
})
export class EditAccountComponent implements OnInit {
  user: any = {};
  registerForm: FormGroup;
  loading = false;
  submitted = false;

  constructor(private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService
  ) {



    this.registerForm = this.formBuilder.group({
      id:[1],
      firstName: [''],
      lastName: [''],
      username: [''],
      email: [''],
      userRoleId: [''],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
        validator: Mustmatch('password', 'confirmPassword')
      });
  }

  

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.userService.getById(params['id']).subscribe(res => {
        this.user = res;
      });
    });

    
  }
  


  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;
    this.loading = true;
    this.userService.update(this.user.id, this.registerForm.value)
      .pipe(first())
      .subscribe(
        data => {
          this.alertService.success('Update successful', true);
          this.router.navigate(['/accounts']);
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }
}
