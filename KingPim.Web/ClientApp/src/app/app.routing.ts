import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { AuthGuard } from './_guards';
import { LoginLayoutComponent } from './_layouts/login-layout.component';
import { HomeLayoutComponent } from './_layouts/home-layout.component';
import { CatalogComponent } from './_pages/catalog';
import { AccountsComponent } from './_pages/accounts';
import { EditAccountComponent } from './_pages/accounts/edit-account/edit-account.component';
import { HomeComponent } from './home';
import { RegisterComponent } from './_pages/accounts/register';
import { ProductGetComponent } from './_pages/catalog/products/product-get/product-get.component';
import { ProductAddComponent } from './_pages/catalog/products/product-add/product-add.component';
import { ProductEditComponent } from './_pages/catalog/products/product-edit/product-edit.component';
import { CategoryGetComponent } from './_pages/catalog/categories/category-get/category-get.component';
import { CategoryAddComponent } from './_pages/catalog/categories/category-add/category-add.component';
import { CategoryEditComponent } from './_pages/catalog/categories/category-edit/category-edit.component';
import { SubcategoryGetComponent } from './_pages/catalog/subcategories/subcategory-get/subcategory-get.component';
import { SubcategoryAddComponent } from './_pages/catalog/subcategories/subcategory-add/subcategory-add.component';
import { SubcategoryEditComponent } from './_pages/catalog/subcategories/subcategory-edit/subcategory-edit.component';
import { AttributegroupGetComponent } from './_pages/catalog/attributegroups/attributegroup-get/attributegroup-get.component';
import { AttributegroupAddComponent } from './_pages/catalog/attributegroups/attributegroup-add/attributegroup-add.component';
import { AttributeGetComponent } from './_pages/catalog/attributes/attribute-get/attribute-get.component';
import { AttributeAddComponent } from './_pages/catalog/attributes/attribute-add/attribute-add.component';
import { AttributeEditComponent } from './_pages/catalog/attributes/attribute-edit/attribute-edit.component';
import { ExportComponent } from './_pages/export/export.component';
import { PublishComponent } from './_pages/publish/publish.component';
import { ResetPassword } from './login/reset-password';
import { NewPassword } from './login/new-password';


const routes: Routes = [

  {
    path: '', component: HomeLayoutComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: HomeComponent },
      { path: 'catalog', component: CatalogComponent },
      { path: 'accounts', component: AccountsComponent },
      { path: 'accounts/:id', component: EditAccountComponent },
      { path: 'export', component: ExportComponent },
      { path: 'product', component: ProductGetComponent },
      { path: 'product/create', component: ProductAddComponent },
      { path: 'product/edit/:id', component: ProductEditComponent },
      { path: 'category', component: CategoryGetComponent },
      { path: 'category/create', component: CategoryAddComponent },
      { path: 'category/edit/:id', component: CategoryEditComponent },
      { path: 'subcategory', component: SubcategoryGetComponent },
      { path: 'subcategory/create', component: SubcategoryAddComponent },
      { path: 'subcategory/edit/:id', component: SubcategoryEditComponent },
      { path: 'attributegroup', component: AttributegroupGetComponent },
      { path: 'attributegroup/create/:id', component: AttributegroupAddComponent },
      { path: 'attribute', component: AttributeGetComponent },
      { path: 'attribute/create', component: AttributeAddComponent },
      { path: 'attribute/edit/:id', component: AttributeEditComponent },
      { path: 'publish', component: PublishComponent }

    ]
  },
  { path: 'register', component: RegisterComponent }, // Removed when going live

  {
    path: '', component: LoginLayoutComponent, children: [
      { path: 'login', component: LoginComponent },
      { path: 'resetpassword', component: ResetPassword },
      { path: 'newpassword/:id/:code', component: NewPassword }
    ]},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

