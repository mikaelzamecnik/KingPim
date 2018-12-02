import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductGetComponent } from '../../catalog/products/product-get/product-get.component';
import { ProductDataService } from '../../../_services/product-data.service';
import { AttributeGroupDataService } from '../../../_services/attribute-group-data.service';
import { Product, AttributeGroup } from '../../../_models';
import { FormGroup, FormBuilder, Validators} from '@angular/forms';



@Component({
  selector: 'app-product-attribute',
  templateUrl: './product-attribute.component.html'})
export class ProductAttributeComponent implements OnInit {
  products: Product[];
  attributegroups: AttributeGroup[];
  angForm: FormGroup;
  myName = 'Mikael';
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    public pr: ProductDataService,
    public ag: AttributeGroupDataService,
    public dialogRef: MatDialogRef<ProductGetComponent>) {
    this.createForm();
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      productId: ['', Validators.required],
      attributeId: ['', Validators.required],
      type: ['', Validators.required],
      value: ['', Validators.required]
    });

  }
  showProducts() {
    this.pr
      .getProducts()
      .subscribe((data: Product[]) => {
        this.products = data;
      });
  }
  showAg() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroups = data;
        console.log(data);
      });
  }
  ngOnInit() {
    this.showProducts();
    this.showAg();
    console.log(this.data);
  }

}
