import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login';
import { AuthGuard } from './_guards';
import { LoginLayoutComponent } from './_layouts/login-layout.component';
import { HomeLayoutComponent } from './_layouts/home-layout.component';
import { CatalogComponent } from './_pages/catalog';
import { AccountsComponent } from './_pages/accounts';
import { HomeComponent } from './home';


const routes: Routes = [

  {
    path: '', component: HomeLayoutComponent, canActivate: [AuthGuard],
    children: [
      { path: '', component: HomeComponent },
      { path: 'catalog', component: CatalogComponent },
      { path: 'accounts', component: AccountsComponent }
    ]
  },

  { path: '', component: LoginLayoutComponent, children: [{ path: 'login', component: LoginComponent }] },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

