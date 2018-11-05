import { Component, OnInit } from '@angular/core';
import { CategoryDataService } from '../../_services/category-data.service';
import { SubCategoryDataService } from '../../_services/sub-category-data.service';
import { ProductDataService } from '../../_services/product-data.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
})

export class CatalogComponent {

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
    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
    subcategoryDataService.GetSubCategories().subscribe((data: any) => this.subcategoryData = data);
    productDataService.GetProducts().subscribe((data: any) => this.productData = data);

    this.currentProduct = this.setInitialValuesForProductData();
    this.currentCategory = this.setInitialValuesForCategoryData();
    this.currentSubCategory = this.setInitialValuesForSubCategoryData();}

  private setInitialValuesForProductData() {
    return {
    }
  }
      private setInitialValuesForCategoryData() {
    return {
    }
  }
          private setInitialValuesForSubCategoryData() {
            return {
            } 

    
  }

  public createOrUpdateProduct = function (product: any) {
    // if product is present in productData this is an update
    // otherwise it is adding a new element
    let productWithId;
    productWithId = _.find(this.productData, (el => el.id === product.id));

    if (productWithId) {
      const updateIndex = _.findIndex(this.productData, { productID: productWithId.id });
      this.productDataService.UpdateProduct(product).subscribe(
        _productRecord => this.productData.splice(updateIndex, 1, product)
      );
    } else {
      this.productDataService.AddProduct(product).subscribe(
        _productRecord => this.productData.push(product)
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
    const deleteIndex = _.findIndex(this.productData, { productID: record.id });
    this.productDataService.RemoveProduct(record).subscribe(
      _result => this.productData.splice(deleteIndex, 1)
    );
  }
}
