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

  constructor(private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService
  ) { this.createForm(); }

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
      this.userService.getById(params['id']).subscribe(res => {
        this.user = res;
      });
    });
  }
  updateUser(firstName, lastName, username, email,
    userRoleId, password, confirmPassword ) {
    this.route.params.subscribe(params => {
      this.userService.update(firstName, lastName, username, email,
        userRoleId, password, confirmPassword, params['id']);
      this.router.navigate(['/accounts']);
    });
  }
}
