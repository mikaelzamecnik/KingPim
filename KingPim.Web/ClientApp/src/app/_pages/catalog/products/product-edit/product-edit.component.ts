import { Component, OnInit } from '@angular/core';
import { ProductDataService, AuthenticationService, UserService } from '../../../../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { SubCategory, AttributeGroup, User, Product } from '../../../../_models';

@Component({
  selector: 'app-product-edit', templateUrl: './product-edit.component.html'})
export class ProductEditComponent implements OnInit {
  product: any = {};
  angForm: FormGroup;
  subcategories: SubCategory[];
  attributegroups: AttributeGroup[];
  currentUser: User;
  productData: Product[];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private ps: ProductDataService,
    private scs: SubCategoryDataService,
    private fb: FormBuilder,
    private authenticationService: AuthenticationService) {
    this.createForm();
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  showSubCategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
        console.log(data);
      });
  }
  // to show products oninit and after deletion
  showProducts() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.productData = data;
        console.log(data);
      });
  }

  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      subCategoryId: ['', Validators.required],
      publishedStatus: ['', Validators.required],
      version: ['', Validators.required],
      editedBy: ['', Validators.required]
    });
  }
  ngOnInit() {
    this.route.params.subscribe(params => {
      this.ps.editProduct(params['id']).subscribe(res => {
        this.product = res;
        console.log(res);
        console.log('UserName', this.currentUser.username);
      });
    });
    this.showSubCategories();
  }
  updateProduct(name, description, subCategoryId, version, editedBy) {
    this.route.params.subscribe(params => {
      this.ps.updateProduct(name, description, subCategoryId, version, editedBy, params['id'])
        .subscribe(res => {
          this.showProducts();
      });
      this.router.navigate(['/catalog']);
    });
  }


}
