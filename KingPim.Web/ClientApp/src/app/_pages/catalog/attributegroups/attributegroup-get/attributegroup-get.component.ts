import { Component, OnInit } from '@angular/core';
import { AttributeGroup } from '../../../../_models/attributegroup';
import { AttributeGroupDataService } from '../../../../_services';
import { MatDialog } from '@angular/material';
import { AttributegroupAddComponent } from '../attributegroup-add/attributegroup-add.component';

@Component({
  selector: 'app-attributegroup-get',
  templateUrl: './attributegroup-get.component.html',
  styleUrls: ['./attributegroup-get.component.css']
})
export class AttributegroupGetComponent implements OnInit {

  attributegroups: AttributeGroup[];

  constructor(
    private ag: AttributeGroupDataService,
    public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(AttributegroupAddComponent, {
      width: '250px',
      backdropClass: 'custom-modalbox'
    });
    //Show result after the button is closed
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
      this.ag
        .getAttributeGroups()
        .subscribe((result: AttributeGroup[]) => {
          this.attributegroups = result;
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
  deleteAttributeGroup(id) {
    this.ag.deleteAttributeGroup(id).subscribe(res => {
      this.showAttributeGroups();
    });
  }

}
