import { Component, OnInit } from '@angular/core';
import * as _ from 'lodash';
import { Product, Category, SubCategory, AttributeGroup, Attribute } from '../../_models';
import {
  ProductDataService,
  SubCategoryDataService,
  CategoryDataService,
  AttributeGroupDataService,
  AttributeDataService
 } from '../../_services';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss'],
})

export class CatalogComponent implements OnInit {

  products: Product[];
  categories: Category[];
  subCategories: SubCategory[];
  attributegroups: AttributeGroup[];
  attributes: Attribute[];

  constructor(
    private ps: ProductDataService,
    private cs: CategoryDataService,
    private scs: SubCategoryDataService,
    private ag: AttributeGroupDataService,
    private att: AttributeDataService
    ) { }

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
  showAttributeGroups() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroups = data;
        this.showAttributeGroups();
      });
  }
  showAttributes() {
    this.att
      .getAttributes()
      .subscribe((data: Attribute[]) => {
        this.attributes = data;
        this.showAttributes();
      });
  }
}
