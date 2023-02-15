import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { BrandListComponent } from './components/lists/brand-list/brand-list.component';
import { MedicinesListComponent } from './components/lists/medicines-list/medicines-list.component';
import { AdminDashboardComponent } from './components/pages/admin-dashboard/admin-dashboard.component';
import { HeaderComponent } from './components/header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PharmacyListComponent } from './components/lists/pharmacy-list/pharmacy-list.component';
import { AddEditBrandModalComponent } from './components/modals/add-edit-brand-modal/add-edit-brand-modal.component';
import { AddEditPharmacyModalComponent } from './components/modals/add-edit-pharmacy-modal/add-edit-pharmacy-modal.component';
import { AddEditMedicineModalComponent } from './components/modals/add-edit-medicine-modal/add-edit-medicine-modal.component';
import { MedicinesPriceListComponent } from './components/lists/medicines-price-list/medicines-price-list.component';
import { AddEditMedicinePriceModalComponent } from './components/modals/add-edit-medicine-price-modal/add-edit-medicine-price-modal.component';
import { MedicinesQuantityListComponent } from './components/lists/medicines-quantity-list/medicines-quantity-list.component';
import { AddEditMedicineCountModalComponent } from './components/modals/add-edit-medicine-count-modal/add-edit-medicine-count-modal.component';
import { ConfirmModalComponent } from './components/modals/confirm-modal/confirm-modal.component';


@NgModule({
  declarations: [
    BrandListComponent,
    MedicinesListComponent,
    AdminDashboardComponent,
    HeaderComponent,
    PharmacyListComponent,
    AddEditBrandModalComponent,
    AddEditPharmacyModalComponent,
    AddEditMedicineModalComponent,
    MedicinesPriceListComponent,
    AddEditMedicinePriceModalComponent,
    MedicinesQuantityListComponent,
    AddEditMedicineCountModalComponent,
    ConfirmModalComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AdminModule { }
