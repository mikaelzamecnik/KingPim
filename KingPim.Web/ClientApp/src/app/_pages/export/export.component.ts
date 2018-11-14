import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-export', templateUrl: './export.component.html'})
export class ExportComponent implements OnInit {
  fileUrl;
  angForm: FormGroup;
  fileformat = ['JSON', 'XML'];
  constructor(
    private sanitizer: DomSanitizer,
    private fb: FormBuilder) {
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
  // Need logic to pick up the jason/xml file from backend
  ngOnInit() {
    const data = 'file info'; // change
    const blob = new Blob([data], { type: 'application/octet-stream' });

    this.fileUrl = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(blob));

  }

}
