import { Component, OnInit } from '@angular/core';
import { SubCategoryDataService } from '../../../../_services';
import { SubCategory } from '../../../../_models';

@Component({
  selector: 'app-subcategory-get',
  templateUrl: './subcategory-get.component.html',
  styleUrls: ['./subcategory-get.component.css']
})
export class SubCategoryGetComponent implements OnInit {

  subCategories: SubCategory[];

  constructor(private scs: SubCategoryDataService) { }

  ngOnInit() {
    this.showSubcategories();
  }
  // to show categories oninit and after deletion
  showSubcategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subCategories = data;
      });
  }
  deleteSubCategory(subCategoryId) {
    this.scs.deleteSubCategory(subCategoryId).subscribe(res => {
      this.showSubcategories();
      console.log('Deleted', subCategoryId);
    });
  }
}

