import { Component, OnInit} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { Category } from '../../../../_models';
import { CategoryDataService } from '../../../../_services';
import { MatDialogRef } from '@angular/material';
import { SubcategoryGetComponent } from '../subcategory-get/subcategory-get.component';

@Component({
  selector: 'app-subcategory-add', templateUrl: './subcategory-add.component.html'})
export class SubcategoryAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  categories: Category[];

  constructor(
    private fb: FormBuilder,
    private cs: CategoryDataService,
    private scs: SubCategoryDataService,
    public dialogRef: MatDialogRef<SubcategoryGetComponent> ) {
      this.createForm(); }

  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      categoryId: ['', Validators.required]
      // Add more
    });

  }
  // Show Categories in Add SubCategory
  showCategories() {
    this.cs
      .getCategories()
      .subscribe((data: Category[]) => {
        this.categories = data;
        console.log(data);
      });
  }
  // Add SubCategory to db
  addSubCategory(name, categoryId) {
    this.loading = true;
    this.scs.addSubCategory(name, categoryId);
  }

  ngOnInit() {
    this.showCategories();
  }

}
