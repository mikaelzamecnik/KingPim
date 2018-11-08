import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { Category } from '../../../../_models';
import { CategoryDataService } from '../../../../_services';

@Component({
  selector: 'app-subcategory-add',
  templateUrl: './subcategory-add.component.html',
  styleUrls: ['./subcategory-add.component.css']
})
export class SubcategoryAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  categories: Category[];

  constructor(
    private fb: FormBuilder,
    private cs: CategoryDataService,
    private scs: SubCategoryDataService,
    private router: Router) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      subcategoryName: ['', Validators.required],
      categoryId: ['', Validators.required]
      // Add more
    });

  }
  //Show Categories in Add SubCategory
  showCategories() {
    this.cs
      .getCategories()
      .subscribe((data: Category[]) => {
        this.categories = data;
        console.log(data);
      });
  }
  // Add SubCategory to db
  addSubCategory(subcategoryName, categoryId) {
    this.loading = true;
    this.scs.addSubCategory(subcategoryName, categoryId);
    this.router.navigate(['/catalog']); //TODO routing goes to fast, backend cant keep up
  }

  ngOnInit() {
    this.showCategories();
  }

}
