import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routing';
import { AlertComponent } from './_components';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { CatalogComponent } from './_pages/catalog';
import { LoginComponent } from './login';
import { RegisterComponent } from './_pages/accounts/register';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AccountsComponent } from './_pages/accounts/accounts.component';
import { CategoryDataService } from './_services/category-data.service';
import { SubCategoryDataService } from './_services/sub-category-data.service';
import { ProductDataService } from './_services/product-data.service';
import * as _ from 'lodash';
import { HomeLayoutComponent } from './_layouts/home-layout.component';
import { LoginLayoutComponent } from './_layouts/login-layout.component';
import { ProductAddComponent } from './_pages/catalog/products/product-add/product-add.component';
import { ProductGetComponent } from './_pages/catalog/products/product-get/product-get.component';
import { ProductEditComponent } from './_pages/catalog/products/product-edit/product-edit.component';
import { SubCategoryGetComponent } from './_pages/catalog/subcategories/subcategory-get/subcategory-get.component';
//import { CategoryAddComponent } from './_pages/catalog/categories/category-add/category-add.component';
//import { CategoryEditComponent } from './_pages/catalog/categories/category-edit/category-edit.component';
import { CategoryGetComponent } from './_pages/catalog/categories/category-get/category-get.component';
//import { SubCategoryAddComponent } from './_pages/catalog/subcategories/subcategory-add/subcategory-add.component';
//import { SubCategoryEditComponent } from './_pages/catalog/subcategories/subcategory-edit/subcategory-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NavMenuComponent,
    AccountsComponent,
    CatalogComponent,
    HomeLayoutComponent,
    LoginLayoutComponent,
    ProductAddComponent,
    ProductGetComponent,
    ProductEditComponent,
    SubCategoryGetComponent,
    //CategoryAddComponent,
    //CategoryEditComponent,
    CategoryGetComponent,
    //SubCategoryAddComponent,
    //SubCategoryEditComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    AngularFontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    CategoryDataService,
    SubCategoryDataService,
    ProductDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
