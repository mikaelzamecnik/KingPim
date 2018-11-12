import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { AttributeGetComponent } from '../../attributes/attribute-get/attribute-get.component';
import { AttributeGroupDataService, SubCategoryDataService, AttributeDataService } from '../../../../_services';
import { AttributeGroup } from '../../../../_models';
import { Attribute } from '../../../../_models';

@Component({
  selector: 'app-attribute-add', templateUrl: './attribute-add.component.html'})
export class AttributeAddComponent implements OnInit {
  angForm: FormGroup;
  attributegroup: AttributeGroup[];
  attributes: Attribute[];

  constructor(
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
    this.showAttribute();
  }
  // Show attributes and child attributevalue, attvalueEnum
  showAttribute() {
    this.att
      .getAttributes()
      .subscribe((data: Attribute[]) => {
        this.attributes = data;
      });
  }
  showAttributeGroups() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroup = data;
      });
  }

}
