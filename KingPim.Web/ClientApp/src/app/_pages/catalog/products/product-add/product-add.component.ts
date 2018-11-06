import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductDataService } from '../../../../_services';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {

  angForm: FormGroup;
  constructor(private fb: FormBuilder, private ps: ProductDataService) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      productName: ['', Validators.required]
      // Add more
    });
  }

  addProduct(productName) {
    this.ps.addProduct(productName);
  }

  ngOnInit() {
  }

}
