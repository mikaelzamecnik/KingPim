import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {
  @Output() productCreated = new EventEmitter<any>();
  @Input() productInfo: any;
  @Input() productData: Array<any>;
  @Input() categoryData: Array<any>;
  @Input() subcategoryData: Array<any>;
  public buttonText = 'Save';

  constructor() {
    this.clearProductInfo();
  }

  ngOnInit() {
  }

  private clearProductInfo = function () {
    // Create an empty product object
    this.productInfo = {
      id: null,
      name: null,
      dateUpdated: '',
      dateCreated:''


    };
  };
  public addOrUpdateProductRecord = function (event) {
    this.productCreated.emit(this.productInfo);
    this.clearProductInfo();
  };

}
