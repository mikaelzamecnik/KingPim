import { Component, OnInit } from '@angular/core';
import { CategoryDataService } from '../../../../_services';
import { Category } from '../../../../_models';
import { MatDialog } from '@angular/material';
import { CategoryAddComponent } from '../category-add/category-add.component';

@Component({
  selector: 'app-category-get',
  templateUrl: './category-get.component.html',
  styleUrls: ['./category-get.component.css']
})
export class CategoryGetComponent implements OnInit {

  categories: Category[];

  constructor(
    private cs: CategoryDataService,
    public dialog: MatDialog) { }

  openDialog(): void {
    const dialogRef = this.dialog.open(CategoryAddComponent, {
      width: '250px',
      
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('Added');
    });
  }

  ngOnInit() {
    this.showCategories();
  }
  // to show categories oninit and after deletion
  showCategories() {
    this.cs
      .getCategories()
      .subscribe((data: Category[]) => {
        this.categories = data;
      });
  }
  deleteCategory(categoryID) {
    this.cs.deleteCategory(categoryID).subscribe(res => {
      this.showCategories();
      console.log('Deleted', categoryID);
    });
  }
}

