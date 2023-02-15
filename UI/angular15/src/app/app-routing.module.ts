import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ShowBrandComponent } from './components/lists/brand-list/show-brand.component';
import { ShowMedicineComponent } from './components/lists/medicine-list/show-medicine.component';
import { ShowPharmacyComponent } from './components/lists/pharmacy-list/show-pharmacy.component';
import { BrandPageComponent } from './components/pages/brand-page/brand-page.component';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { MainPageComponent } from './components/pages/main-page/main-page.component';
import { MedicinePageComponent } from './components/pages/medicine-page/medicine-page.component';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { AuthorizationGuard } from './guards/authorization.guard';

const routes: Routes = [
  {path: '', component: MainPageComponent},
  {path: 'brand', component: ShowBrandComponent},
  {path: 'pharmacy-list/:brandId', component: ShowPharmacyComponent},
  {path: 'pharmacy', component: ShowPharmacyComponent},
  {path: 'medicine', component: ShowMedicineComponent},
  {path: 'medicine-page/:medicineId', component: MedicinePageComponent},
  {path: 'brand-page', component: BrandPageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'admin', canActivate: [AuthorizationGuard], canDeactivate: [AuthorizationGuard], loadChildren: () => import('./components/admin/admin.module').then((m) => m.AdminModule)},
  {path: '**', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
