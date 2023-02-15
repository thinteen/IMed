import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrand } from 'src/app/interface/brand.interface';
import { IMedicineCount } from 'src/app/interface/medicineCount.interface';
import { IMedicinePrice } from 'src/app/interface/medicinePrice.interface';
import { IPharmacy } from 'src/app/interface/pharmacy.interface';
import { IPharmacyMedicine } from 'src/app/interface/pharmacyMedicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-medicines-quantity-list',
  templateUrl: './medicines-quantity-list.component.html',
  styleUrls: ['./medicines-quantity-list.component.css']
})
export class MedicinesQuantityListComponent {

  pharmacyMedicineList!: IPharmacyMedicine[];

  pharmacyMedicineCount!: IMedicineCount;

  pharmacyId!: number;

  modalTitle!: string;

  pharmacy!: IPharmacy;

  activateAddEditMedicineCountComponent: boolean = false;

  editOrAdd!: number;

  medicineIdForEdit?: number

  constructor(private activateRoute: ActivatedRoute, private service: SharedService) {
    this.pharmacyId = activateRoute.snapshot.params['pharmacyId'];
  }

  ngOnInit(): void {
    this.refreshMedicineQuantityList();
  }

  refreshMedicineQuantityList() {
    this.service.getPharmacyMedicinesById(this.pharmacyId).subscribe((data: IPharmacyMedicine[]) => {
      this.pharmacyMedicineList = data;
    })
  }

  deleteMedicine(medicineId?: number) {
    this.service.deleteMedicineFromPharmacy(medicineId!, this.pharmacyId).subscribe((data: IPharmacyMedicine) => {
      this.refreshMedicineQuantityList();
    })
  }

  addMedicine() {
    this.pharmacyMedicineCount = {
      pharmacyId: 0,
      medicineId: 0,
      residual: 0,
    }
    this.modalTitle = "Добавление препарата";
    this.activateAddEditMedicineCountComponent = true;
    this.editOrAdd = 1;
    console.log(this.editOrAdd);
  }

  closeClick() {
    this.activateAddEditMedicineCountComponent = false;
    this.editOrAdd = 0;
    this.refreshMedicineQuantityList();
  }

  editClick(item: IMedicineCount) {
    // this.medicineIdForEdit = medicineId;
    this.pharmacyMedicineCount = item;
    this.modalTitle = "Редактирование количества";
    this.editOrAdd = 2;
    this.activateAddEditMedicineCountComponent = true;

    console.log(this.editOrAdd);
  }
}
