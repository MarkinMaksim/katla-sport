import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { HiveFormComponent } from './hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from './hive-management/forms/hive-section-form.component';
import { HiveListComponent } from './hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from './hive-management/lists/hive-section-list.component';
import { ProductCategoryFormComponent } from './product-management/forms/product-category-form.component';
import { ProductFormComponent } from './product-management/forms/product-form.component';
import { ProductCategoryListComponent } from './product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from './product-management/lists/product-category-product-list.component';
import { ProductListComponent } from './product-management/lists/product-list.component';
import { AccountantListComponent } from './accountant-managment/lists/accountant-list.component';
import { AccountantFormComponent } from './accountant-managment/form/accountant-form.component';
import { CompanyListComponent } from './company-managment/lists/company-list.component';
import { CompanyFormComponent } from './company-managment/form/company-form.component';
import { ReportListComponent } from './report-managment/lists/report-list.component';
import { ReportFormComponent } from './report-managment/form/report-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainPageComponent },
  { path: 'categories', component: ProductCategoryListComponent },
  { path: 'category', component: ProductCategoryFormComponent },
  { path: 'category/:id', component: ProductCategoryFormComponent },
  { path: 'category/:id/products', component: ProductCategoryProductListComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'product/:id', component: ProductFormComponent },
  { path: 'category/:categoryId/product/:id', component: ProductFormComponent },
  { path: 'hives', component: HiveListComponent },
  { path: 'hive', component: HiveFormComponent },
  { path: 'hive/:id', component: HiveFormComponent },
  { path: 'hive/:id/sections', component: HiveSectionListComponent },
  { path: 'hive/:store-hive-id/section', component: HiveSectionFormComponent },
  { path: 'hive/:store-hive-id/section/:id', component: HiveSectionFormComponent },
  { path: 'accountants', component: AccountantListComponent },
  { path: 'accountant/:id', component: AccountantFormComponent },
  { path: 'accountant', component: AccountantFormComponent },
  { path: 'companys', component: CompanyListComponent },
  { path: 'company/:id', component: CompanyFormComponent },
  { path: 'company', component: CompanyFormComponent },
  { path: 'reports', component: ReportListComponent },
  { path: 'report/:id', component: ReportFormComponent },
  { path: 'report', component: ReportFormComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }