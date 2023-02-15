import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { IQuantityMedicineInPharmacy } from 'src/app/interface/quantityMedicineInPharmacy.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-medicine-page',
  templateUrl: './medicine-page.component.html',
  styleUrls: ['./medicine-page.component.css']
})
export class MedicinePageComponent {

  medicineId?: number;

  medicine!: IMedicine;

  isInfo: boolean = true;

  quantityMedicineInPharmacyList: IQuantityMedicineInPharmacy[] = [];

  constructor(private activateRoute: ActivatedRoute, private service: SharedService) {
    this.medicineId = activateRoute.snapshot.params['medicineId'];
  }

  ngOnInit(): void {
    this.getQuantityMedicineInPharmacyById();
  }

  getQuantityMedicineInPharmacyById() {
    if (this.medicineId != 0) {
      this.service.getQuantityMedicineInPharmacyById(this.medicineId).subscribe((data: IQuantityMedicineInPharmacy[]) => {
        this.quantityMedicineInPharmacyList = data;
        if (this.quantityMedicineInPharmacyList.length == 0) {
          this.isInfo = false;
        }
      })
    }
  }

  getMedicineByid() {
    this.service.getMedicineById(this.medicineId).subscribe((data: IMedicine) => {
      this.medicine = data;
    })
  }
}