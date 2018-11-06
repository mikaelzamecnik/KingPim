import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { CategoryDataService } from '../../_services';

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

  constructor(private categoryDataService: CategoryDataService) {
    this.clearProductInfo();
    this.categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
  }

  ngOnInit() {
  }


  private clearProductInfo = function () {
    // Create an empty product object
    this.productInfo = {
    };
  };
  public addOrUpdateProductRecord = function (event) {
    this.productCreated.emit(this.productInfo);

  };

}
