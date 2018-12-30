import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AttributeGetComponent } from '../../attributes/attribute-get/attribute-get.component';
import { AttributeGroupDataService, SubCategoryDataService, AttributeDataService } from '../../../../_services';
import { AttributeGroup, Attribute } from '../../../../_models';

@Component({
  selector: 'app-attribute-add', templateUrl: './attribute-add.component.html'})
export class AttributeAddComponent implements OnInit {
  angForm: FormGroup;
  angFormValue: FormGroup;
  attributegroup: AttributeGroup[];
  attg: any = {};
  attributes: Attribute[];
  loading = false;
  selectedValue: string = '';
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
      attributegroupId: ['', Validators.required],
      name: ['', Validators.required],
      description: ['', Validators.required],
      type: ['', Validators.required],
      attributeOptionListId: [''],
      attributeOptionList: ['']
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
  addAttribute(name, description, type, attributegroupId, attributeOptionListId, attributeOptionList) {
    this.loading = true;
    this.att.addAttribute(name, description, type, attributegroupId, attributeOptionListId, attributeOptionList);
    console.log(name, type, attributegroupId);
  }

}
