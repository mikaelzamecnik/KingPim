import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SubCategoryDataService } from '../../../../_services/sub-category-data.service';
import { MatDialogRef } from '@angular/material';
import { AttributegroupGetComponent } from '../../attributegroups/attributegroup-get/attributegroup-get.component';
import { SubCategory } from '../../../../_models';
import { AttributeGroupDataService } from '../../../../_services';

@Component({
  selector: 'app-attributegroup-add', templateUrl: './attributegroup-add.component.html'})
export class AttributegroupAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;
  subcategories: SubCategory[];

  constructor(
    private fb: FormBuilder,
    private ag: AttributeGroupDataService,
    private scs: SubCategoryDataService,
    public dialogRef: MatDialogRef<AttributegroupGetComponent> ) {
      this.createForm(); }

  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      subcategoryId: ['', Validators.required]
      // Add more
    });

  }

  showSubCategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
        console.log(data);
      });
  }
  // Add AttributeGroup to db
  addAttributeGroup(name, subcategoryId) {
    this.loading = true;
    this.ag.addAttributeGroup(name, subcategoryId);
  }

  ngOnInit() {
    this.showSubCategories();
  }

}
