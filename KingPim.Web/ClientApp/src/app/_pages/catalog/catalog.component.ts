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
      const updateIndex = _.findIndex(this.productData, { id: productWithId.id });
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
    const deleteIndex = _.findIndex(this.productData, { id: record.id });
    this.productDataService.RemoveProduct(record).subscribe(
      _result => this.productData.splice(deleteIndex, 1)
    );
  }

  public createOrUpdateCategory = function (category: any) {
    // if category is present in productData this is an update
    // otherwise it is adding a new element
    let categoryWithId;
    categoryWithId = _.find(this.categoryData, (el => el.id === category.id));

    if (categoryWithId) {
      const updateIndex = _.findIndex(this.categoryData, { id: categoryWithId.id });
      this.categoryDataService.UpdateCategory(category).subscribe(
        _categoryRecord => this.categoryData.splice(updateIndex, 1, category)
      );
    } else {
      this.categoryDataService.AddCategory(category).subscribe(
        _categoryRecord => this.productData.push(category)
      );
    }

    this.currentproduct = this.setInitialValuesForCategoryData();
  };

  public editCategoryClicked = function (record) { 
    this.currentCategory = record;
  };

  public newCategoryClicked = function () {
    this.currentCategory = this.setInitialValuesForCategoryData();
  };

  public deleteCategoryClicked(record) {
    const deleteIndex = _.findIndex(this.categoryData, { id: record.id });
    this.categoryDataService.RemoveCategory(record).subscribe(
      _result => this.categoryData.splice(deleteIndex, 1)
    );
  }


}
