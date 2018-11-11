import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { AttributeGetComponent } from '../../attributes/attribute-get/attribute-get.component';

@Component({
  selector: 'app-attribute-add', templateUrl: './attribute-add.component.html'})
export class AttributeAddComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<AttributeGetComponent>) { }

  ngOnInit() {
  }
  onNoClick(): void {
    this.dialogRef.close();
  }

}
