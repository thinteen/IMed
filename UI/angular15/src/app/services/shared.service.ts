import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http'; 
import { Observable } from 'rxjs';
import { IBrand } from '../interface/brand.interface';
import { IPharmacy } from '../interface/pharmacy.interface';
import { IMedicine } from '../interface/medicine.interface';
import { IQuantityMedicineInPharmacy } from '../interface/quantityMedicineInPharmacy.interface';
import { IBrandPharmacy } from '../interface/brandPharmacy.interface';
import { IAdminAccount } from '../interface/adminAccount.interface';
import { IMedicinePrice } from '../interface/medicinePrice.interface';
import { IBrandMedicinePrice } from '../interface/brandMedicinePrice.interface';
import { IPharmacyMedicine } from '../interface/pharmacyMedicine.interface';
import { IMedicineCount } from '../interface/medicineCount.interface';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly Url = "http://localhost:4300";
  readonly APIUrl = "http://localhost:4300/api";

  constructor(private http:HttpClient) { }

  getAllBrand():Observable<IBrand[]>{
    return this.http.get<IBrand[]>(this.APIUrl + '/brand/get-all');
  }

  getAllPharmacy():Observable<IPharmacy[]>{
    return this.http.get<IPharmacy[]>(this.APIUrl + '/pharmacy/get-all');
  }

  getAllMedicine():Observable<IMedicine[]>{
    return this.http.get<IMedicine[]>(this.APIUrl + '/medicine/get-all');
  }

  getPopularMedicine():Observable<IMedicine[]>{
    return this.http.get<IMedicine[]>(this.APIUrl + '/medicine/get-popular-medicine');
  }

  getMedicineByName(searchString: string):Observable<IMedicine[]>{
    return this.http.get<IMedicine[]>(this.APIUrl + '/medicine/get-medicine-by-name?medicineName=' + searchString);
  }

  getMedicineByCategory(category: string):Observable<IMedicine[]>{
    return this.http.get<IMedicine[]>(this.APIUrl + '/medicine/get-medicine-by-category?medicineCategory=' + category);
  }

  getMedicineWithPriceByBrandId(brandId?: number):Observable<IMedicinePrice[]>{
    return this.http.get<IMedicinePrice[]>(this.APIUrl + '/medicine/get-medicine-with-price-by-brandId?brandId=' + brandId);
  }

  getBrandByName(searchString: string):Observable<IBrand[]>{
    return this.http.get<IBrand[]>(this.APIUrl + '/brand/get-brand-by-name?brandName=' + searchString);
  }

  getBrandById(brandId?: number):Observable<IBrand>{
    return this.http.get<IBrand>(this.APIUrl + '/brand/get-brand-by-brandId?brandId=' + brandId);
  }

  getPharmacyById(pharmacyId?: number):Observable<IPharmacy>{
    return this.http.get<IPharmacy>(this.APIUrl + '/pharmacy/get-pharmacy-by-id?pharmacyId=' + pharmacyId);
  }

  getMedicineById(medicineId?: number):Observable<IMedicine>{
    return this.http.get<IMedicine>(this.APIUrl + '/medicine/get-medicine-by-id?medicineId=' + medicineId);
  }

  getPharmacyMedicinesById(pharmacyId?: number):Observable<IPharmacyMedicine[]>{
    return this.http.get<IPharmacyMedicine[]>(this.APIUrl + '/medicine/get-pharmacy-medicines-by-id?pharmacyId=' + pharmacyId);
  }

  getQuantityMedicineInPharmacyById(medicineId?: number):Observable<IQuantityMedicineInPharmacy[]>{
    return this.http.get<IQuantityMedicineInPharmacy[]>(this.APIUrl + '/medicine/get-medicine-with-price-and-place-of-purchase-by-id?medicineId=' + medicineId);
  }

  getPharmaciesByBrandId(brandId?: number):Observable<IBrandPharmacy[]>{
    return this.http.get<IBrandPharmacy[]>(this.APIUrl + '/pharmacy/' + brandId + '/get-pharmacies-by-brandId');
  }

  getAdminAccountPasswordByLogin(login?: string): Observable<IAdminAccount> {
    return this.http.get<IAdminAccount>(this.APIUrl + '/adminaccount/get-admin-account-password-by-login?login=' + login);
  }

  deleteMedicine(medicineId: number): Observable<IMedicine> {
    return this.http.delete<IMedicine>(this.APIUrl + '/medicine/'+ medicineId +'/delete');
  }

  deleteBrand(brandId: number): Observable<IBrand> {
    return this.http.delete<IBrand>(this.APIUrl + '/brand/'+ brandId +'/delete');
  }

  deleteBrandMedicinePrice(medicineId: number, brandId: number): Observable<IBrandMedicinePrice> {
    return this.http.delete<IBrandMedicinePrice>(this.APIUrl + '/medicine/delete-brand-medicine-price?medicineId=' + medicineId + '&brandId=' + brandId);
  }

  deleteMedicineFromPharmacy(medicineId: number, pharmacyId: number): Observable<IPharmacyMedicine> {
    return this.http.delete<IPharmacyMedicine>(this.APIUrl + '/medicine/delete-medicine-from-pharmacy?medicineId=' + medicineId + '&pharmacyId=' + pharmacyId);
  }

  deletePharmacy(pharmacyId: number): Observable<IPharmacy> {
    return this.http.delete<IPharmacy>(this.APIUrl + '/pharmacy/' + pharmacyId + '/delete');
  }

  addBrand(data: IBrand) {
    return this.http.post(this.APIUrl + '/brand/add', data);
  }

  addPharmacy(data: IPharmacy) {
    return this.http.post(this.APIUrl + '/pharmacy/add', data);
  }

  addMedicine(data: IMedicine) {
    return this.http.post(this.APIUrl + '/medicine/add', data);
  }

  addMedicinePriceForBrand(data: IBrandMedicinePrice) {
    return this.http.post(this.APIUrl + '/medicine/add-medicine-price-for-brand', data);
  }

  addResidualMedicineInPharmacy(data: IMedicineCount) {
    return this.http.post(this.APIUrl + '/medicine/add-residual-medicine-in-pharmacy', data);
  }

  editMedicine(data: IMedicine) {
    return this.http.put(this.APIUrl + '/medicine/update', data);
  }

  editBrandMedicinePrice(data: IBrandMedicinePrice) {
    return this.http.put(this.APIUrl + '/medicine/update-brand-medicine-price', data);
  }

  editCountOfMedicineInPharmacy(data: IMedicineCount) {
    return this.http.put(this.APIUrl + '/medicine/update-count-of-medicine-in-pharmacy', data);
  }

  editBrand(data: IBrand) {
    return this.http.put(this.APIUrl + '/brand/update', data);
  }

  editPharmacy(data: IPharmacy) {
    return this.http.put(this.APIUrl + '/pharmacy/update', data);
  }

  uploadPhoto(data: any) {
    let q: any = this.http.post(this.Url + '/SavePhoto', data);
    q.subscribe((data: any) => {
      console.log(data);
    })
    return q;
  }
}