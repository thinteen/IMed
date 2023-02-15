import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowBrandComponent } from './components/lists/brand-list/show-brand.component';
import { ShowPharmacyComponent } from './components/lists/pharmacy-list/show-pharmacy.component';
import { ShowMedicineComponent } from './components/lists/medicine-list/show-medicine.component';
import { MedicinePageComponent } from './components/pages/medicine-page/medicine-page.component';

import { SharedService } from './services/shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrandPageComponent } from './components/pages/brand-page/brand-page.component';
import { LoginPageComponent } from './components/pages/login-page/login-page.component';
import { NotFoundPageComponent } from './components/pages/not-found-page/not-found-page.component';
import { MainPageComponent } from './components/pages/main-page/main-page.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowBrandComponent,
    ShowPharmacyComponent,
    ShowMedicineComponent,
    MedicinePageComponent,
    BrandPageComponent,
    LoginPageComponent,
    NotFoundPageComponent,
    MainPageComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
