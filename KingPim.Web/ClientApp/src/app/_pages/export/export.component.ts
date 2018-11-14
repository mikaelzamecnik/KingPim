import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-export', templateUrl: './export.component.html'})
export class ExportComponent implements OnInit {
  fileUrl;
  constructor(private sanitizer: DomSanitizer) { }

  ngOnInit() {
    const data = 'file info';
    const blob = new Blob([data], { type: 'application/octet-stream' });

    this.fileUrl = this.sanitizer.bypassSecurityTrustResourceUrl(window.URL.createObjectURL(blob));

  }

}
