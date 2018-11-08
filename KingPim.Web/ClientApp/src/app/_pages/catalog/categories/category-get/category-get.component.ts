import { Component, OnInit } from '@angular/core';
import { CategoryDataService } from '../../../../_services';
import { Category } from '../../../../_models';

@Component({
  selector: 'app-category-get',
  templateUrl: './category-get.component.html',
  styleUrls: ['./category-get.component.css']
})
export class CategoryGetComponent implements OnInit {

  categories: Category[];

  constructor(private cs: CategoryDataService) { }

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

