import { Component, OnInit } from '@angular/core';
import { AttributeGroup } from '../../../../_models/attributegroup';
import { Attribute } from '../../../../_models/attribute';
import { AttributeGroupDataService } from '../../../../_services';
import { AttributeDataService } from '../../../../_services';
import { MatDialog } from '@angular/material';
import { AttributegroupAddComponent } from '../attributegroup-add/attributegroup-add.component';
import { AttributeAddComponent } from '../../attributes/attribute-add/attribute-add.component';

@Component({
  selector: 'app-attributegroup-get', templateUrl: './attributegroup-get.component.html'})
export class AttributegroupGetComponent implements OnInit {

  attributegroups: AttributeGroup[];
  attributes: Attribute[];

  constructor(
    private ag: AttributeGroupDataService,
    private att: AttributeDataService,
    public dialog: MatDialog) { }
  // OpenModal For add new attributegroup
  openAgDialog(): void {
    const dialogRef = this.dialog.open(AttributegroupAddComponent, {
      width: '250px',
      backdropClass: 'custom-modalbox'
    });
    // Show result after the button is closed
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
      this.ag
        .getAttributeGroups()
        .subscribe((_result: AttributeGroup[]) => {
          this.attributegroups = _result;
        });
    });
  }
   // OpenModal For add new attribute
  openAttDialog(id) {
     const dialogRef = this.dialog.open(AttributeAddComponent, {
       width: '250px',
       data: {
         agId: id
       } ,
       backdropClass: 'custom-modalbox',
    });
    // Show result after the button is closed
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
      this.att
        .getAttributes()
        .subscribe((_result: Attribute[]) => {
          this.attributes = _result;
        });
    });
  }

  ngOnInit() {
    this.showAttributeGroups();
  }
  // to show products oninit and after deletion
  showAttributeGroups() {
    this.ag
      .getAttributeGroups()
      .subscribe((data: AttributeGroup[]) => {
        this.attributegroups = data;
      });
  }
  getAttributeGroup(id) {
    this.ag.getAttributeGroup(id).subscribe(res => {
    });
    console.log('ID', id);
  }
  // delete attributegroup
  deleteAttributeGroup(id) {
    this.ag.deleteAttributeGroup(id).subscribe(res => {
      this.showAttributeGroups();
    });
  }

}
