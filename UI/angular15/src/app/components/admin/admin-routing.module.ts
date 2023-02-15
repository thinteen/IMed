import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainPageComponent } from '../pages/main-page/main-page.component';
import { BrandListComponent } from './components/lists/brand-list/brand-list.component';
import { MedicinesListComponent } from './components/lists/medicines-list/medicines-list.component';
import { MedicinesPriceListComponent } from './components/lists/medicines-price-list/medicines-price-list.component';
import { MedicinesQuantityListComponent } from './components/lists/medicines-quantity-list/medicines-quantity-list.component';
import { PharmacyListComponent } from './components/lists/pharmacy-list/pharmacy-list.component';
import { AdminDashboardComponent } from './components/pages/admin-dashboard/admin-dashboard.component';

const routes: Routes = [
  {path: '', component: AdminDashboardComponent,
    children: [
      {path: '', redirectTo: 'brand-list', pathMatch: 'full' },
      {path: 'brand-list', component: BrandListComponent},
      {path: 'medicine-list', component: MedicinesListComponent},
      {path: 'pharmacy-list/:brandId', component: PharmacyListComponent},
      {path: 'medicines-price-list/:brandId', component: MedicinesPriceListComponent},
      {path: 'medicines-quantity-list/:pharmacyId', component: MedicinesQuantityListComponent}
    ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
