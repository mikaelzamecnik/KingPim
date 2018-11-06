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

  ngOnInit() {
    this.showProducts();
  }
  // to show products oninit and after deletion
  showProducts() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
  deleteProduct(productID) {
    this.ps.deleteProduct(productID).subscribe(res => {
      this.showProducts();
      console.log('Deleted', productID);
    });
  }
}
