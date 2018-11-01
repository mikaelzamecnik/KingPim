import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { AlertComponent } from './_components';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { CatalogComponent } from './catalog';
import { LoginComponent } from './login';
import { RegisterComponent } from './register';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MainCatalogComponent } from './main-catalog/main-catalog.component';
import { AccountsComponent } from './accounts/accounts.component';
import { ToolsComponent } from './tools/tools.component';
import { AssetsLibraryComponent } from './assets-library/assets-library.component';
import { CategoryDataService } from './_services/category-data.service';
import { SubCategoryDataService } from './_services/sub-category-data.service';
import { ProductDataService } from './_services/product-data.service';
import * as _ from 'lodash';
import { ShowAllProductsComponent } from './show-all-products/show-all-products.component';
import { AddEditProductComponent } from './add-edit-product/add-edit-product.component';

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NavMenuComponent,
    MainCatalogComponent,
    AccountsComponent,
    ToolsComponent,
    AssetsLibraryComponent,
    ShowAllProductsComponent,
    AddEditProductComponent,
    CatalogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    routing,
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
