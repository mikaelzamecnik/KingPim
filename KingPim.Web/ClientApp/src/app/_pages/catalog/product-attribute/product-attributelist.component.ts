import { Component, OnInit, Inject, Output, EventEmitter } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { AttributeGroupDataService } from '../../../_services/attribute-group-data.service';
import { Product, AttributeGroup, Attribute, AttributeValue, AttributeList, AttributeListValue } from '../../../_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttributeDataService, AttributelistDataService } from '../../../_services';
import { AttributeValueDataService } from '../../../_services';

@Component({
  selector: 'app-product-attributelist',
  templateUrl: './product-attributelist.component.html'
})
export class ProductAttributelistComponent implements OnInit {

  productvalues: Product[];
  attributegroups: AttributeGroup[];
  attributelist: AttributeList[];
  attributelistvalue: AttributeListValue[];
  angForm: FormGroup;
  angFormList: FormGroup;
  loading: boolean;
  value = '';
  selectedValue: number;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private attl: AttributelistDataService,
    public pr: ProductDataService,
    public ag: AttributeGroupDataService,
    public att: AttributeDataService,
    public attv: AttributeValueDataService,
    public dialogRef: MatDialogRef<ProductGetComponent>) {
    this.createFormList();
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  onSelect(attlid) {
    console.log('List' + attlid);
  }
  createFormList() {
    this.angFormList = this.fb.group({
      productId: ['', Validators.required],
      productattributeId: ['', Validators.required],
      value: ['', Validators.required],
    });
  }
  addAttributeListValue(productId, productattributeId, value) {
    this.attv.addAttributevalue(productId, productattributeId, value)
      .subscribe(_res => {
      });
  }
  getAttributeList() {
    this.attl.getAttributeLists()
      .subscribe((data: AttributeList[]) => {
        this.attributelist = data;
      });
  }
  getAttributeListValues() {
    this.attl.getAttributeListValues()
      .subscribe((data: AttributeListValue[]) => {
        this.attributelistvalue = data;
        console.log('Whole List', data);
      });
  }

  //// Single List Value
  //getAttributeListValue(id) {
  //  this.attl.getAttributeListValue(id)
  //    .subscribe((data: AttributeListValue[]) => {
  //      this.attributelistvalue = data;
  //      console.log("from SingleList" + data);
  //    });
  //}

  showProducts() {
    this.pr
      .getProducts()
      .subscribe((data: Product[]) => {
        this.productvalues = data;
      });
  }
  ngOnInit() {
    this.showProducts();
    this.getAttributeList();
    this.getAttributeListValues();
  }

}
