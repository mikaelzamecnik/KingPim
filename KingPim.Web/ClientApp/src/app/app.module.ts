import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MainCatalogComponent } from './main-catalog/main-catalog.component';
import { AccountsComponent } from './accounts/accounts.component';
import { ToolsComponent } from './tools/tools.component';
import { AssetsLibraryComponent } from './assets-library/assets-library.component';
import { CategoryDataService } from './category-data.service';
import { SubCategoryDataService } from './sub-category-data.service';
import * as _ from 'lodash';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    MainCatalogComponent,
    AccountsComponent,
    ToolsComponent,
    AssetsLibraryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },

    ])
  ],
  providers: [
    CategoryDataService,
    SubCategoryDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }