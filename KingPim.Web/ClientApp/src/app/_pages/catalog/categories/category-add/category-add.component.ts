import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoryDataService } from '../../../../_services/category-data.service';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css']
})
export class CategoryAddComponent implements OnInit {
  loading = false;
  angForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private cs: CategoryDataService,
    private router: Router)
  {
    this.createForm();
  }
  createForm() {
    this.angForm = this.fb.group({
      categoryName: ['', Validators.required]
      // Add more
    });

  }
  // Add Category to db
  addCategory(categoryName) {
    this.loading = true;
    this.cs.addCategory(categoryName);
    this.router.navigate(['/catalog']); //TODO routing goes to fast, backend cant keep up
  }

  ngOnInit() {
  }

}
