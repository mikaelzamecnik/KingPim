import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AttributeGetComponent } from '../../attributes/attribute-get/attribute-get.component';
import { AttributeGroupDataService, SubCategoryDataService, AttributeDataService } from '../../../../_services';
import { AttributeGroup } from '../../../../_models';
import { Attribute } from '../../../../_models';

@Component({
  selector: 'app-attribute-add', templateUrl: './attribute-add.component.html'})
export class AttributeAddComponent implements OnInit {
  angForm: FormGroup;
  attributegroup: AttributeGroup[];
  attg: any = {};
  attributes: Attribute[];
  loading = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private ag: AttributeGroupDataService,
    public scs: SubCategoryDataService,
    public att: AttributeDataService,
    public dialogRef: MatDialogRef<AttributeGetComponent>) {
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      attributegroupId: ['', Validators.required],
      type: ['', Validators.required]
      // Add more
    });

  }
  ngOnInit() {
    this.showAttributeGroups();
    console.log(this.data);
  }
  showAttributeGroups() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroup = data;
      });
  }
  // Add Attribute to db
  addAttribute(name, description, type) {
    this.loading = true;
    this.att.addAttribute(name, description,type);
  }

}
