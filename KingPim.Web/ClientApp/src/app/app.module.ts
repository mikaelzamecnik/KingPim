import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { AttributeGroupDataService } from './_services/attribute-group-data.service';
import { AttributeDataService } from './_services/attribute-data.service';
import { MaterialModule } from './material';
import * as _ from 'lodash';
import { HomeLayoutComponent } from './_layouts/home-layout.component';
import { LoginLayoutComponent } from './_layouts/login-layout.component';
import { ProductAddComponent } from './_pages/catalog/products/product-add/product-add.component';
import { ProductGetComponent } from './_pages/catalog/products/product-get/product-get.component';
import { ProductEditComponent } from './_pages/catalog/products/product-edit/product-edit.component';
import { CategoryAddComponent } from './_pages/catalog/categories/category-add/category-add.component';
import { CategoryEditComponent } from './_pages/catalog/categories/category-edit/category-edit.component';
import { CategoryGetComponent } from './_pages/catalog/categories/category-get/category-get.component';
import { SubcategoryAddComponent } from './_pages/catalog/subcategories/subcategory-add/subcategory-add.component';
import { SubcategoryEditComponent } from './_pages/catalog/subcategories/subcategory-edit/subcategory-edit.component';
import { SubcategoryGetComponent } from './_pages/catalog/subcategories/subcategory-get/subcategory-get.component';
import { AttributegroupAddComponent } from './_pages/catalog/attributegroups/attributegroup-add/attributegroup-add.component';
import { AttributegroupEditComponent } from './_pages/catalog/attributegroups/attributegroup-edit/attributegroup-edit.component';
import { AttributegroupGetComponent } from './_pages/catalog/attributegroups/attributegroup-get/attributegroup-get.component';
import { AttributeAddComponent } from './_pages/catalog/attributes/attribute-add/attribute-add.component';
import { AttributeEditComponent } from './_pages/catalog/attributes/attribute-edit/attribute-edit.component';
import { AttributeGetComponent } from './_pages/catalog/attributes/attribute-get/attribute-get.component';

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
    CategoryAddComponent,
    CategoryEditComponent,
    CategoryGetComponent,
    SubcategoryGetComponent,
    SubcategoryAddComponent,
    SubcategoryEditComponent,
    AttributegroupAddComponent,
    AttributegroupEditComponent,
    AttributegroupGetComponent,
    AttributeAddComponent,
    AttributeEditComponent,
    AttributeGetComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    AngularFontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule

  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    CategoryDataService,
    SubCategoryDataService,
    ProductDataService,
    AttributeGroupDataService,
    AttributeDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
