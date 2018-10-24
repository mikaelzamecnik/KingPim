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


  constructor(
    private categoryDataService: CategoryDataService,
    private subcategoryDataService: SubCategoryDataService,
    private productDataService: ProductDataService)
  {
    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
    subcategoryDataService.GetSubCategories().subscribe((data: any) => this.subcategoryData = data);
    productDataService.GetProducts().subscribe((data: any) => this.productData = data);
  }


}
