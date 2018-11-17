import { Component, OnInit } from '@angular/core';
import { ProductDataService } from '../../../../_services';
import { Product } from '../../../../_models';
import { MatDialog, } from '@angular/material';
import { ProductAttributeComponent } from '../../product-attribute/product-attribute.component';

@Component({
  selector: 'app-product-get', templateUrl: './product-get.component.html'
})

export class ProductGetComponent implements OnInit {

  columnsToDisplay: string[] = ['Id', 'Name', 'SubCategory',
    'Created', 'Updated', 'Version', 'Editedby', 'Published', 'Edit', 'Delete'];
  productData: Product[];

  constructor(private ps: ProductDataService,
    public dialog: MatDialog) {
  }
  // Opens attribute modal
  openProdAttDialog(id) {
    this.dialog.open(ProductAttributeComponent, {
      width: '500px',
      backdropClass: 'custom-modalbox',
      data: {
        apId: id
      },
    });
    console.log('opened', id);
  }
  ngOnInit() {
    this.showProducts();
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
}
