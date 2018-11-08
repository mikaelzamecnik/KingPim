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

  subCategories: SubCategory[];

  constructor(private scs: SubCategoryDataService,
    public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(SubcategoryAddComponent, {
      width: '250px',

    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
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
        this.subCategories = data;
        console.log(data);
      });
  }
  deleteSubCategory(subCategoryId) {
    this.scs.deleteSubCategory(subCategoryId).subscribe(res => {
      this.showSubcategories();
      console.log('Deleted', subCategoryId);
    });
  }
}

