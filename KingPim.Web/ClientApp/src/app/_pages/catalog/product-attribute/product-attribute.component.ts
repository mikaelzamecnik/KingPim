import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { Product } from '../../../_models';


@Component({
  selector: 'app-product-attribute',
  templateUrl: './product-attribute.component.html'})
export class ProductAttributeComponent implements OnInit {
  products: Product[];
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public pr: ProductDataService,
    public dialogRef: MatDialogRef<ProductGetComponent> ) { }
  onNoClick(): void {
    this.dialogRef.close();
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
