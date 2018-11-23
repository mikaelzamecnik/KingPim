import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { interval } from 'rxjs';
import { CategoryDataService } from '../../../../_services/category-data.service';
import { Category } from '../../../../_models';
import { MatDialogRef } from '@angular/material';
import { CategoryGetComponent } from '../category-get/category-get.component';

@Component({
  selector: 'app-category-add', templateUrl: './category-add.component.html'})
export class CategoryAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  categories: Category[];


  constructor(
    private fb: FormBuilder,
    private cs: CategoryDataService,
    public dialogRef: MatDialogRef<CategoryGetComponent>) {
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required]
    });

  }
  // Add Category to db
  addCategory(name) {
    this.loading = true;
    this.cs.addCategory(name);
  }

  ngOnInit() {
  }

}
