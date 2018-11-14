import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductDataService } from '../../../../_services';
import { Router } from '@angular/router';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { SubCategory } from '../../../../_models';

@Component({
  selector: 'app-product-add', templateUrl: './product-add.component.html'})
export class ProductAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  subcategories: SubCategory[];

  constructor(
    private fb: FormBuilder,
    private ps: ProductDataService,
    private scs: SubCategoryDataService,
    private router: Router) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      subCategoryId: ['', Validators.required],
      attributeGroup: ['', Validators.required],
      attribute: ['', Validators.required],
      value: ['', Validators.required]


      // Add more
    });

  }
  // Show SubCategories in Add Product
  showSubCategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
        console.log(data);
      });
  }
  // Add Product to db
  addProduct(name, description, subCategoryId) {
    console.log(subCategoryId);
    this.loading = true;
    this.ps.addProduct(name, description, subCategoryId);
    this.router.navigate(['catalog']); // TODO routing goes to fast, backend cant keep up
  }

  ngOnInit() {
    this.showSubCategories();
  }

}
