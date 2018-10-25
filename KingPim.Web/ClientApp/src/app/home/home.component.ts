import { Component, OnInit } from '@angular/core';
import { CategoryDataService } from './../category-data.service';
import { SubCategoryDataService } from './../sub-category-data.service';
import { ProductDataService } from './../product-data.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public categoryData: Array<any>;
  public subcategoryData: Array<any>;
  public productData: Array<any>;
  public currentProduct: any;
  public currentCategory: any;
  public currentSubCategory: any;


  constructor(
    private categoryDataService: CategoryDataService,
    private subcategoryDataService: SubCategoryDataService,
    private productDataService: ProductDataService)
  {
    this.currentProduct = this.setInitialValuesForProductData();

    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
    subcategoryDataService.GetSubCategories().subscribe((data: any) => this.subcategoryData = data);
    productDataService.GetProducts().subscribe((data: any) => this.productData = data);
  }

  private setInitialValuesForProductData() {
    return {
      id: undefined,
    }
  }

  public createOrUpdateProduct = function (product: any) {
    // if product is present in productData this is an update
    // otherwise it is adding a new element
    let productWithId;
    productWithId = _.find(this.productData, (el => el.id === product.id));

    if (productWithId) {
      const updateIndex = _.findIndex(this.productData, { id: productWithId.id });
      this.productService.UpdateProduct(product).subscribe(
        productRecord => this.productData.splice(updateIndex, 1, product)
      );
    } else {
      this.productService.AddProduct(product).subscribe(
        productRecord => this.productData.push(product)
      );
    }

    this.currentproduct = this.setInitialValuesForProductData();
  };

  public editClicked = function (record) {
    this.currentProduct = record;
  };

  public newClicked = function () {
    this.currentProduct = this.setInitialValuesForProductData();
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.productData, { id: record.id });
    this.productDataService.RemoveProduct(record).subscribe(
      result => this.productData.splice(deleteIndex, 1)
    );
  }


}
