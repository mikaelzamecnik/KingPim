import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductDataService, AuthenticationService } from '../../../../_services';
import { Product, User } from '../../../../_models';
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
  openProdAttDialog(id, name, subCategory) {
    this.dialog.open(ProductAttributeComponent, {
      width: '800px',
      backdropClass: 'custom-modalbox',
      data: {
        apId: id,
        apName: name,
        apSC: subCategory
      },
    });
    console.log('opened', id);
  }
  ngOnInit() {
    this.showProducts();
  }
  changeStatus(id, publishedStatus) {
    this.ps.updateProductStatus(id, publishedStatus)
    this.showProducts(); // Need some delay or observable state
    console.log(publishedStatus);
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
