import { Component, OnInit, Input } from '@angular/core';
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

  @Input() categoryData: Array<any>;
  @Input() categoryInfo: any;
  registerForm: FormGroup;
  loading = false;
  submitted = false;


  

  constructor(private categoryDataService: CategoryDataService, private formBuilder: FormBuilder,
    private alertService: AlertService) {

    categoryDataService.GetCategories().subscribe((data: any) => this.categoryData = data);
    
  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    this.loading = false;
    this.categoryDataService.AddCategory(this.registerForm.value)
      .pipe(first())
      .subscribe(
        _data => {
          this.alertService.success('Registration successful', true);
          this.categoryDataService.GetCategories;
          // Why dosent it refresh SPA
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });
  }


}
