import { Component, OnInit } from '@angular/core';
import { AttributeGroup } from '../../../../_models/attributegroup';
import { Attribute } from '../../../../_models/attribute';
import { AttributeGroupDataService, AttributelistDataService } from '../../../../_services';
import { AttributeDataService } from '../../../../_services';
import { MatDialog } from '@angular/material';
import { AttributegroupAddComponent } from '../attributegroup-add/attributegroup-add.component';
import { AttributeAddComponent } from '../../attributes/attribute-add/attribute-add.component';
import { AttributelistAddComponent } from '../../attributes/attributelist/attributelist-add.component';
import { AttributeList } from '../../../../_models/attributelist';

@Component({
  selector: 'app-attributegroup-get', templateUrl: './attributegroup-get.component.html'})
export class AttributegroupGetComponent implements OnInit {

  attributegroups: AttributeGroup[];
  attributes: Attribute[];
  attributelist: AttributeList[];
constructor(
    private ag: AttributeGroupDataService,
  private att: AttributeDataService,
  private attl: AttributelistDataService,
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
          this.showAttributeGroups();
        });
    });
  }
   // OpenModal For add new attribute LIST
  openAttListDialog(id, name) {
    const dialogRef = this.dialog.open(AttributelistAddComponent, {
      width: '250px',
      data: {
        agId: id,
        agName: name
      },
       backdropClass: 'custom-modalbox',
    });
    // Show result after the button is closed
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
      this.attl
        .getAttributeLists()
        .subscribe((_result: AttributeList[]) => {
          this.attributelist = _result;
        });
    });
  }

  // OpenModal For add new attribute
  openAttDialog(id, name) {
    const dialogRef = this.dialog.open(AttributeAddComponent, {
      width: '250px',
      data: {
        agId: id,
        agName: name
      },
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
  showAttributes() {
    this.att
      .getAttributes()
      .subscribe((data: Attribute[]) => {
        this.attributes = data;
      });
  }
  // delete attributegroup
  deleteAttributeGroup(id) {
    this.ag.deleteAttributeGroup(id).subscribe(res => {
      this.showAttributeGroups();
    });
  }

}
