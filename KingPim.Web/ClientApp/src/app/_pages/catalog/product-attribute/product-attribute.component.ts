import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { AttributeGroupDataService } from '../../../_services/attribute-group-data.service';
import { Product, AttributeGroup, Attribute, AttributeValue } from '../../../_models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttributeDataService } from '../../../_services';
import { AttributeValueDataService } from '../../../_services';
import { delay } from 'q';



@Component({
  selector: 'app-product-attribute',
  templateUrl: './product-attribute.component.html'})
export class ProductAttributeComponent implements OnInit {
  productvalues: Product[];
  attributegroups: AttributeGroup[];
  attributes: Attribute[];
  attvalues: AttributeValue[];
  angForm: FormGroup;
    loading: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
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

  }
  // Add AttributeGroup to db
  addAttributeValue(productId, productattributeId, value) {
    console.log(productId, productattributeId, value);
    this.attv.addAttributevalue(productId, productattributeId, value);
    this.loading = true;
    delay(500);

  }
  showAttv() {
    this.attv
      .getAttributevalues()
      .subscribe((data: AttributeValue[]) => {
        this.attvalues = data;
        console.log(data);
      });
  }
  showProducts() {
    this.pr
      .getProducts()
      .subscribe((data: Product[]) => {
        this.productvalues = data;
        console.log("SingleData",data);
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
    this.showAtt()
  }

}
