import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { Product } from '../../../_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';



@Component({
  selector: 'app-product-attribute',
  templateUrl: './product-attribute.component.html'})
export class ProductAttributeComponent implements OnInit {
  products: Product[];
  angForm: FormGroup;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    public pr: ProductDataService,
    public dialogRef: MatDialogRef<ProductGetComponent>) {
    this.createForm();
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      productId: ['', Validators.required],
      attributeId: ['', Validators.required],
      type: ['', Validators.required],
      value: ['', Validators.required]
    });

  }
  showProducts() {
    this.pr
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
  ngOnInit() {
    this.showProducts();
    console.log(this.data);
  }

}
