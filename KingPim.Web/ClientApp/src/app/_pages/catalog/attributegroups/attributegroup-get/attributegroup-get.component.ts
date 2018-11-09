import { Component, OnInit } from '@angular/core';
import { AttributeGroup } from '../../../../_models/attributegroup';
import { AttributeGroupDataService } from '../../../../_services';

@Component({
  selector: 'app-attributegroup-get',
  templateUrl: './attributegroup-get.component.html',
  styleUrls: ['./attributegroup-get.component.css']
})
export class AttributegroupGetComponent implements OnInit {

  attributegroups: AttributeGroup[];

  constructor(private ag: AttributeGroupDataService) { }

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
