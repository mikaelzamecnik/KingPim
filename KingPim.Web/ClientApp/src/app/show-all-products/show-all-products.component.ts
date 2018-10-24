import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-show-all-products',
  templateUrl: './show-all-products.component.html',
  styleUrls: ['./show-all-products.component.css']
})
export class ShowAllProductsComponent implements OnInit {

  @Input() productData: Array<any>;

  constructor() { }

  ngOnInit() {
  }

}
