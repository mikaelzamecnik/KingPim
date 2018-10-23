import { Component, OnInit } from '@angular/core';
import { CategoryDataService } from './../category-data.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {

  public categoryData: Array<any>;
  public currentCategory: any;

  constructor (private categoryDataService: CategoryDataService) {
    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
}

}
