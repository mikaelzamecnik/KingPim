import { Component, OnInit } from '@angular/core';
import { ProductDataService } from '../../../../_services';
import { Product } from '../../../../_models';

@Component({
  selector: 'app-product-get',
  templateUrl: './product-get.component.html',
  styleUrls: ['./product-get.component.css']
})
export class ProductGetComponent implements OnInit {

  products: Product[];

  constructor(private ps: ProductDataService) { }

  deleteProduct(productID) {
    this.ps.deleteProduct(productID).subscribe(_res => {
      console.log('Deleted',productID);
    });
  }

  ngOnInit() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }

}
