import {Component} from '@angular/core';
import { ProductDataService } from '../../_services/product-data.service';


@Component({
  selector: 'app-publish',
  templateUrl: './publish.component.html'})
export class PublishComponent {

  constructor(
    private ps: ProductDataService) {}

    updateProductStatus(publishedStatus) {
      this.ps.updateProductStatus(publishedStatus);
    }
 }
