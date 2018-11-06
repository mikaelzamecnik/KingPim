import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
import { ProductDataService } from '../../_services';

@Component({
  selector: 'app-show-all-products',
  templateUrl: './show-all-products.component.html',
  styleUrls: ['./show-all-products.component.css']
})
export class ShowAllProductsComponent implements OnInit {

  @Output() recordDeleted = new EventEmitter<any>();
  @Output() newClicked = new EventEmitter<any>();
  @Output() editClicked = new EventEmitter<any>();
  @Input() productData: Array<any>;
  @Input() productInfo: any;



  constructor(private productDataService: ProductDataService) { }

  ngOnInit() {
  }
  public deleteRecord(record) {
    this.recordDeleted.emit(record);
  }

  public editRecord(record) {
    const clonedRecord = Object.assign({}, record);
    this.editClicked.emit(clonedRecord);


  }

  public newRecord() {
    this.newClicked.emit();
  }
  onSubmit() {
    this.productDataService.GetProducts().subscribe((data: any) => this.productData = data);}

}
