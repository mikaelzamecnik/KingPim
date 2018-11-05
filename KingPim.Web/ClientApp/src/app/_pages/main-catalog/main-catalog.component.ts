import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { CategoryDataService } from '../../_services/category-data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AlertService } from '../../_services';


@Component({
  selector: 'app-main-catalog',
  templateUrl: './main-catalog.component.html',
  styleUrls: ['./main-catalog.component.css']
})
export class MainCatalogComponent implements OnInit {

  @Output() categoryCreated = new EventEmitter<any>();
  @Input() categoryData: Array<any>;
  @Input() categoryInfo: any;
  categoryForm: FormGroup;
  loading = false;
  submitted = false;


  

  constructor(private categoryDataService: CategoryDataService, private formBuilder: FormBuilder,
    private alertService: AlertService) {

    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);

  }

  ngOnInit() {
    this.categoryForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }
  get f() { return this.categoryForm.controls; }
  
  onSubmit() {
    this.submitted = true;
    

    if (this.categoryForm.invalid) {
      return;
    }

    this.loading = false;
    this.categoryDataService.AddCategory(this.categoryForm.value)
      .pipe(first())
      .subscribe(
      _data => {
        console.log(_data);
        this.alertService.success('Category Added', true);
        this.categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
        
        
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
      });
    
  }


}
