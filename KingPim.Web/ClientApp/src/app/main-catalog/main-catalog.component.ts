import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-main-catalog',
  templateUrl: './main-catalog.component.html',
  styleUrls: ['./main-catalog.component.css']
})



export class MainCatalogComponent implements OnInit {

  @Input() categoryData: Array<any>;

  constructor() { }

  ngOnInit() {
  }

}
