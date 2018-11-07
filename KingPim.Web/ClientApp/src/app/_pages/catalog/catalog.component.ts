import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Product } from '../../_models';
import { ProductDataService } from '../../_services';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
})

export class CatalogComponent implements OnInit {

  products: Product[];

  constructor(private ps: ProductDataService) { }

  ngOnInit() {
    this.showProducts();
  }


  showProducts() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
}
