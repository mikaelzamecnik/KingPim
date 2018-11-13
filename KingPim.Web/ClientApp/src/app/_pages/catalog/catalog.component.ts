import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Product, Category, SubCategory } from '../../_models';
import { ProductDataService, SubCategoryDataService, CategoryDataService } from '../../_services';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss'],
})

export class CatalogComponent implements OnInit {

  products: Product[];
  categories: Category[];
  subCategories: SubCategory[];

  constructor(
    private ps: ProductDataService,
    private cs: CategoryDataService,
    private scs: SubCategoryDataService) { }

  ngOnInit() { }
  showProducts() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
        this.showProducts();
      });
  }
  showCategories() {
    this.cs
      .getCategories()
      .subscribe((data: Category[]) => {
        this.categories = data;
        this.showCategories();
      });
  }
  showSubcategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subCategories = data;
        this.showSubcategories();
      });
  }
}
