import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IBrandMedicinePrice } from 'src/app/interface/brandMedicinePrice.interface';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { IMedicineCount } from 'src/app/interface/medicineCount.interface';
import { IMedicinePrice } from 'src/app/interface/medicinePrice.interface';
import { IPharmacy } from 'src/app/interface/pharmacy.interface';
import { IPharmacyMedicine } from 'src/app/interface/pharmacyMedicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-medicine-count-modal',
  templateUrl: './add-edit-medicine-count-modal.component.html',
  styleUrls: ['./add-edit-medicine-count-modal.component.css']
})
export class AddEditMedicineCountModalComponent {

  constructor(private activateRoute: ActivatedRoute, private service: SharedService) {
    this.tempPharmacyId = activateRoute.snapshot.params['pharmacyId'];
  }
  brandId!: number;

  tempPharmacyId?: number;

  input!: FormGroup;

  medicineList!: IMedicine[];


  @Input() pharmacyMedicineCount!: IMedicineCount;
  @Input() medicineIdForEdit?: number;
  @Input() editOrAdd?: number;

  pharmacyId?: number;
  medicineId?: number;
  residual!: number;

  editAdd?: number;

  editMedicineId?: number;

  tempMedicineId?: number;

  medicineNameInBrand!: IMedicinePrice[];

  

  searchName: string = "";


  ngOnInit() {
    this.editAdd = this.editOrAdd,
    this.editMedicineId = this.medicineIdForEdit,
    this.pharmacyId = this.pharmacyMedicineCount.pharmacyId,
    this.medicineId = this.pharmacyMedicineCount.medicineId,
    this.residual = this.pharmacyMedicineCount.residual,

    this.getAllMedicinesInBrand();
  }

  addMedicine() {
    var val = {
      pharmacyId: this.tempPharmacyId, 
      medicineId: this.tempMedicineId, 
      residual: this.residual,
    }

    this.service.addResidualMedicineInPharmacy(val).subscribe(res => {
    })
  }

  editMedicine() {
    var val = {
      pharmacyId: this.tempPharmacyId, 
      medicineId: this.medicineId, 
      residual: this.residual
    }

    this.service.editCountOfMedicineInPharmacy(val).subscribe(res => {
    })
  }

  getAllMedicinesInBrand() {
    this.service.getPharmacyById(this.tempPharmacyId).subscribe((data: IPharmacy)=>{

      this.service.getMedicineWithPriceByBrandId(data.brandId).subscribe((data: IMedicinePrice[]) => {
        this.medicineNameInBrand = data;
      })  
    })
  }

  getMedicineIdByName() {
    if (this.searchName != '') 
    {
      this.service.getMedicineByName(this.searchName).subscribe((data: IMedicine[]) => {
        this.tempMedicineId = data[0].medicineId;
        console.log(this.tempMedicineId);
      })
    };
  }
}
