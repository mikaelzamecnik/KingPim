import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-edit-product',
  templateUrl: './add-edit-product.component.html',
  styleUrls: ['./add-edit-product.component.css']
})
export class AddEditProductComponent implements OnInit {
  @Output() productCreated = new EventEmitter<any>();
  @Input() productInfo: any;
  public buttonText = 'Save';
  @Input() subcategoryData: Array<any>;

  constructor() {
    this.clearProductInfo();
  }

  ngOnInit() {
  }

  private clearProductInfo = function () {
    // Create an empty product object
    this.productInfo = {
      name: "",
      
      
    };
  };
  public addOrUpdateProductRecord = function (event) {
    this.productCreated.emit(this.productInfo);
    this.clearProductInfo();
  };

}
