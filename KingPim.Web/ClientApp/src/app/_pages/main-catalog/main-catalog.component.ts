import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';


@Component({
  selector: 'app-main-catalog',
  templateUrl: './main-catalog.component.html',
  styleUrls: ['./main-catalog.component.css']
})
export class MainCatalogComponent implements OnInit {

  @Output() recordCategoryDeleted = new EventEmitter<any>();
  @Output() newCategoryClicked = new EventEmitter<any>();
  @Input() categoryData: Array<any>;
  @Input() subcategoryData: Array<any>;
  @Output() categoryCreated = new EventEmitter<any>();
  @Input() categoryInfo: any;
  @Output() subcategoryCreated = new EventEmitter<any>();
  @Input() subcategoryInfo: any;
  public buttonText = 'Save';
  

  constructor() {
    this.clearCategoryInfo();
    this.clearSubCategoryInfo();
  }

  ngOnInit() {
  }

  private clearCategoryInfo = function () {
    // Create an empty category object
    this.categoryInfo = {
      id: null,
      name: null,
    };
  };
private clearSubCategoryInfo = function () {
    // Create an empty product object
    this.subcategoryInfo = {
      id: null,
      name: null,
    };
};
  public addOrUpdateCategoryRecord = function (event) {
    this.categoryCreated.emit(this.categoryInfo);
    this.clearCategoryInfo();
  };
  public addOrUpdateSubCategoryRecord = function (event) {
    this.subcategoryCreated.emit(this.subcategoryInfo);
    this.clearSubCategoryInfo();
  };

  public newCategoryRecord() {
    this.newCategoryClicked.emit();
  }

  public deleteCategoryRecord(record) {
    this.recordCategoryDeleted.emit(record);
}

}
