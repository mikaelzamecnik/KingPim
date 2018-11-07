import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { AuthGuard } from './_guards';
import { LoginLayoutComponent } from './_layouts/login-layout.component';
import { HomeLayoutComponent } from './_layouts/home-layout.component';
import { CatalogComponent } from './_pages/catalog';
import { AccountsComponent } from './_pages/accounts';
import { HomeComponent } from './home';
import { RegisterComponent } from './_pages/accounts/register';
import { ProductGetComponent } from './_pages/catalog/products/product-get/product-get.component';
import { ProductAddComponent } from './_pages/catalog/products/product-add/product-add.component';
import { ProductEditComponent } from './_pages/catalog/products/product-edit/product-edit.component';
import { SubCategoryGetComponent } from './_pages/catalog/subcategories/subcategory-get/subcategory-get.component';
//import { SubCategoryAddComponent } from './_pages/catalog/subcategories/subcategory-add/subcategory-add.component';
//import { SubCategoryEditComponent } from './_pages/catalog/subcategories/subcategory-edit/subcategory-edit.component';


const routes: Routes = [

  {
    path: '', component: HomeLayoutComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: HomeComponent },
      { path: 'catalog', component: CatalogComponent },
      { path: 'accounts', component: AccountsComponent },
      { path: 'product', component: ProductGetComponent },
      { path: 'product/create', component: ProductAddComponent },
      { path: 'product/edit/:id', component: ProductEditComponent },
      { path: 'subcategory', component: SubCategoryGetComponent },
      //{ path: 'subcategory/create', component: SubCategoryAddComponent },
      //{ path: 'subcategory/edit/:id', component: SubCategoryEditComponent },

    ]
  },
  { path: 'register', component: RegisterComponent }, //Removed when going live

  { path: '', component: LoginLayoutComponent, children: [{ path: 'login', component: LoginComponent }] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

