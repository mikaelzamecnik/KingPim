import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Product } from '../../_models/';
import { ProductDataService } from '../../_services/product-data.service';
import {HttpClient} from '@angular/common/http';
import { saveAs } from 'file-saver';
import { ExportService } from '../../_services/export.service';

@Component({
  selector: 'app-export', templateUrl: './export.component.html'})
export class ExportComponent implements OnInit {
  fileUrl;
  angForm: FormGroup;
  products: Product[];
  fileformat = ['JSON', 'XML'];
  jsonProducts: any;
 constructor(   private sanitizer: DomSanitizer,
    private fb: FormBuilder,
    private ps: ProductDataService,
    private http: HttpClient,
    private ex: ExportService) {
      this.createForm();
     }
     createForm() {
      this.angForm = this.fb.group({
        format: ['', Validators.required],
        categories: [false, Validators.required],
        subcategories: [false, Validators.required],
        products: [false, Validators.required]
      });
     }
// Export Products to json file
  exportProductJson() {
    this.ex.getProductsToJson().subscribe(data => saveAs(data, `products.json`));
    console.log(saveAs);
  }
  exportCategoryJson() {
    this.ex.getCategoriesToJson().subscribe(data => saveAs(data, `categories.json`));
    console.log(saveAs);
  }
  exportSubCategoryJson() {
    this.ex.getSubCategoriesToJson().subscribe(data => saveAs(data, `subcategories.json`));
    console.log(saveAs);
  }
  ngOnInit() {
  }

}
