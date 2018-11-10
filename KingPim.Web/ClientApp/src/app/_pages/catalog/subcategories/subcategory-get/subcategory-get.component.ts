import { Component, OnInit } from '@angular/core';
import { SubCategoryDataService } from '../../../../_services';
import { SubCategory } from '../../../../_models';
import { MatDialog } from '@angular/material';
import { SubcategoryAddComponent } from '../subcategory-add/subcategory-add.component';

@Component({
  selector: 'app-subcategory-get',
  templateUrl: './subcategory-get.component.html',
  styleUrls: ['./subcategory-get.component.css']
})
export class SubcategoryGetComponent implements OnInit {

  subcategories: SubCategory[];

  constructor(
    private scs: SubCategoryDataService,
    public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(SubcategoryAddComponent, {
      width: '250px',
      backdropClass: 'custom-modalbox',

    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
      this.scs
        .getSubCategories()
        .subscribe((result: SubCategory[]) => {
          this.subcategories = result;
        });
    });
  }

  ngOnInit() {
    this.showSubcategories();
  }
  // to show categories oninit and after deletion
  showSubcategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
      });
  }
  deleteSubCategory(subCategoryID) {
    this.scs.deleteSubCategory(subCategoryID).subscribe(res => {
      this.showSubcategories();
      console.log('Deleted', subCategoryID);
    });
  }
}

