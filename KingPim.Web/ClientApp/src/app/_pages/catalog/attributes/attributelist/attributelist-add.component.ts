import { Component, OnInit, Inject } from '@angular/core';
import { AttributeList, AttributeListValue } from '../../../../_models/attributelist';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AttributelistDataService } from '../../../../_services/attributelist-data.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-attributelist-add',
  templateUrl: './attributelist-add.component.html'
})
export class AttributelistAddComponent implements OnInit {
  attg: any = {};
  loading = false;
  angForm: FormGroup;
  angFormValue: FormGroup;
  attributelist: AttributeList[];
  attributelistvalue: AttributeListValue[];


  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private attl: AttributelistDataService,
    public dialogRef: MatDialogRef<AttributelistAddComponent>) {
    this.createForm();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required]
    });
    this.angFormValue = this.fb.group({
      attributeOptionListId: ['', Validators.required],
      listValue: ['', Validators.required]
    });

  }

  // Handles the attributelist values

  addAttributeListValue(attributeOptionListId, listValue) {
    this.loading = true;
    this.attl.addAttributeListValue(attributeOptionListId, listValue);
  }

  getAttributeListValues() {
    this.attl.getAttributeListValues()
      .subscribe((data: AttributeListValue[]) => {
        this.attributelistvalue = data;
      });
  }

  // Handles the attribute list
  addAttributeList(name) {
    this.loading = true;
    this.attl.addAttributeList(name);
  }

  getAttributeLists() {
    this.attl.getAttributeLists()
      .subscribe((data: AttributeList[]) => {
        this.attributelist = data;
      });
    this.getAttributeLists();
  }

  ngOnInit() {
    this.getAttributeLists();
  }
}
