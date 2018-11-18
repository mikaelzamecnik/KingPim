import { Component, OnInit } from '@angular/core';
import { ProductDataService } from '../../../../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { SubCategory } from '../../../../_models';

@Component({
  selector: 'app-product-edit', templateUrl: './product-edit.component.html'})
export class ProductEditComponent implements OnInit {
  product: any = {};
  angForm: FormGroup;
  subcategories: SubCategory[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private ps: ProductDataService,
    private scs: SubCategoryDataService,
    private fb: FormBuilder) {
    this.createForm();
  }

  showSubCategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
        console.log(data);
      });
  }

  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      subCategoryId: ['', Validators.required],
      attributeGroup: ['', Validators.required],
      attribute: ['', Validators.required],
      value: ['', Validators.required],
      publishedStatus: ['', Validators.required]
    });
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.ps.editProduct(params['id']).subscribe(res => {
        this.product = res;
      });
    });
  }
  updateProduct(name, description, subcategoryId, publishedStatus) {
    this.route.params.subscribe(params => {
      this.ps.updateProduct(name, description, subcategoryId, publishedStatus, params['id']);
      console.log(publishedStatus);
      this.router.navigate(['catalog']);
    });
  }


}
