import { Component, OnInit } from '@angular/core';
import { SubCategoryDataService } from '../../../../_services';
import { SubCategory } from '../../../../_models';
import { MatDialog } from '@angular/material';
import { SubcategoryAddComponent } from '../subcategory-add/subcategory-add.component';

@Component({
  selector: 'app-subcategory-get', templateUrl: './subcategory-get.component.html'})
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
        .subscribe((_result: SubCategory[]) => {
          this.subcategories = _result;
        });
    });
  }
  ngOnInit() {
    this.showSubcategories();
  }
  // to show subcategories oninit and after deletion
  showSubcategories() {
    this.scs
      .getSubCategories()
      .subscribe((data: SubCategory[]) => {
        this.subcategories = data;
      });
  }
  deleteSubCategory(id) {
    this.scs.deleteSubCategory(id).subscribe(res => {
      this.showSubcategories();
      console.log('Deleted', id);
    });
  }
}

