import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { AttributeGroupDataService } from '../../../_services/attribute-group-data.service';
import { Product, AttributeGroup, Attribute, AttributeValue, AttributeList, AttributeListValue } from '../../../_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttributeDataService, AttributelistDataService } from '../../../_services';
import { AttributeValueDataService } from '../../../_services';
import { delay } from 'q';



@Component({
  selector: 'app-product-attribute',
  templateUrl: './product-attribute.component.html'
})
export class ProductAttributeComponent implements OnInit {
  productvalues: Product[];
  attributegroups: AttributeGroup[];
  attributes: Attribute[];
  attvalues: AttributeValue[];
  attributelist: AttributeList[];
  attributelistvalue: AttributeListValue[];
  angForm: FormGroup;
  angFormList: FormGroup;
  loading: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private attl: AttributelistDataService,
    public pr: ProductDataService,
    public ag: AttributeGroupDataService,
    public att: AttributeDataService,
    public attv: AttributeValueDataService,
    public dialogRef: MatDialogRef<ProductGetComponent>) {
    this.createForm();
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      productId: ['', Validators.required],
      productattributeId: ['', Validators.required],
      value: ['', Validators.required],
    });
    this.angFormList = this.fb.group({
      productId: ['', Validators.required],
      productattributeId: ['', Validators.required],
      value: ['', Validators.required],
    });

  }
  addAttributeValue(productId, productattributeId, value) {
    this.attv.addAttributevalue(productId, productattributeId, value)
      .subscribe(res => {
        this.showProducts();
        this.angForm.reset();
      });
  }
  showAttv() {
    this.attv
      .getAttributevalues()
      .subscribe((data: AttributeValue[]) => {
        this.attvalues = data;
        console.log(data);
      });
  }
  getAttributeList() {
    this.attl.getAttributeLists()
      .subscribe((data: AttributeList[]) => {
        this.attributelist = data;
        console.log(data);
      });
  }
  getAttributeListValue() {
    this.attl.getAttributeListValues()
      .subscribe((data: AttributeListValue[]) => {
        this.attributelistvalue = data;
        console.log(data);
      });
  }
  showProducts() {
    this.pr
      .getProducts()
      .subscribe((data: Product[]) => {
        this.productvalues = data;
        console.log("SingleData", data);
      });
  }
  showAg() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroups = data;

      });
  }
  showAtt() {
    this.att
      .getAttributes()
      .subscribe((data: Attribute[]) => {
        this.attributes = data;
        console.log(data);
      });
  }
  ngOnInit() {
    this.showProducts();
    this.showAg();
    this.showAtt();
    this.getAttributeList();
    this.getAttributeListValue();
  }

}
