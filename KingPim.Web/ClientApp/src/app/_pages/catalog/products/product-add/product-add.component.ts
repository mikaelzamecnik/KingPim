import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ProductDataService } from '../../../../_services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private ps: ProductDataService,
    private router: Router) {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      productName: ['', Validators.required]
      // Add more
    });
    
  }

  addProduct(productName) {
    this.loading = true;
    this.ps.addProduct(productName);
    this.router.navigate(['/catalog']); //TODO routing goes to fast, backend cant keep up
  }

  ngOnInit() {
  }

}
