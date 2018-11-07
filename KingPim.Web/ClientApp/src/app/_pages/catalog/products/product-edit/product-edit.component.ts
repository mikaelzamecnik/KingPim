import { Component, OnInit } from '@angular/core';
import { ProductDataService } from '../../../../_services';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: any = {};
  angForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private ps: ProductDataService,
    private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      productName: ['', Validators.required],
    });
  }
  

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.ps.editProduct(params['id']).subscribe(res => {
        console.log(res);
        this.product = res;
      });
    });
  }
  updateProduct(productName) {
    this.route.params.subscribe(params => {
      console.log(params, productName);
      this.ps.updateProduct(productName, params['id']);
      console.log(params, productName);
      this.router.navigate(['catalog']);
    });
  }


}
