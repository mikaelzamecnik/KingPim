import { Component, OnInit } from '@angular/core';
import { ProductDataService } from '../../../../_services';
import { Product } from '../../../../_models';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-get',
  templateUrl: './product-get.component.html',
  styleUrls: ['./product-get.component.css']
})
export class ProductGetComponent implements OnInit {

  columnsToDisplay: string[] = ['Id', 'Name', 'Category', 'SubCategory',
    'Created', 'Updated', 'Version', 'Editedby', 'Published', 'Edit', 'Delete'];
  productData: Product[];
  angForm: FormGroup;
  panelOpenState = false;

  constructor(private ps: ProductDataService,
    private route: ActivatedRoute,
    private fb: FormBuilder) {
    this.createForm();
  }

  ngOnInit() {
    this.showProducts();
  }
  createForm() {
    this.angForm = this.fb.group({
      publishedStatus: ['']
    });
  }
  // to show products oninit and after deletion
  showProducts() {
    this.ps
      .getProducts()
      .subscribe((data: Product[]) => {
        this.productData = data;
        console.log(data);
      });
  }
  deleteProduct(productID) {
    this.ps.deleteProduct(productID).subscribe(res => {
      this.showProducts();
      console.log('Deleted', productID);
    });
  }
  editProduct(productID) {
    this.ps.editProduct(productID).subscribe(res => {
     });
     console.log('ID', productID);
  }
  updateProduct(productID, productName) {
    this.ps.updateProduct(productID, productName);
    }
    }
