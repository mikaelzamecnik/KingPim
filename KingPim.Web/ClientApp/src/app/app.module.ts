import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { MainCatalogComponent } from './main-catalog/main-catalog.component';
import { AccountsComponent } from './accounts/accounts.component';
import { ToolsComponent } from './tools/tools.component';
import { AssetsLibraryComponent } from './assets-library/assets-library.component';
import { CategoryDataService } from './_services/category-data.service';
import { SubCategoryDataService } from './_services/sub-category-data.service';
import { ProductDataService } from './_services/product-data.service';
import { DecimalPipe } from '@angular/common';
import { DatePipe } from '@angular/common';
import * as _ from 'lodash';
import { ShowAllProductsComponent } from './show-all-products/show-all-products.component';
import { AddEditProductComponent } from './add-edit-product/add-edit-product.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    MainCatalogComponent,
    AccountsComponent,
    ToolsComponent,
    AssetsLibraryComponent,
    ShowAllProductsComponent,
    AddEditProductComponent,
    RegistrationFormComponent,
    LoginFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AngularFontAwesomeModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'accounts', component: AccountsComponent },
      { path: 'assets-library', component: AssetsLibraryComponent },
      { path: 'tools', component: ToolsComponent },

    ])
  ],
  providers: [
    CategoryDataService,
    SubCategoryDataService,
    ProductDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
