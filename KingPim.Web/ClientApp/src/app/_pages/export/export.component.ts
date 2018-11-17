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
    exportPdf() {
      this.ex.export().subscribe(data => saveAs(data, `pdf RR2018.pdf`));
  }
  ngOnInit() {
  }

}
