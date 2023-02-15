import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrand } from 'src/app/interface/brand.interface';
import { IBrandMedicinePrice } from 'src/app/interface/brandMedicinePrice.interface';
import { IBrandPharmacy } from 'src/app/interface/brandPharmacy.interface';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { IMedicinePrice } from 'src/app/interface/medicinePrice.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-medicines-price-list',
  templateUrl: './medicines-price-list.component.html',
  styleUrls: ['./medicines-price-list.component.css']
})
export class MedicinesPriceListComponent {

  brandId?: number;

  medicineList!: IMedicinePrice[];

  brand!: IBrand;

  brandMedicinePrice!: IBrandMedicinePrice;

  modalTitle!: string;

  activateAddEditMedicinePriceComponent: boolean = false;

  medicineIdForEdit?: number

  editOrAdd?: number;

  constructor(private activateRoute: ActivatedRoute, private service:SharedService) {
    this.brandId = activateRoute.snapshot.params['brandId'];
  }

  ngOnInit(): void {
    this.refreshMedicinePriceList();
  }

  refreshMedicinePriceList() {
    this.service.getMedicineWithPriceByBrandId(this.brandId).subscribe((data: IMedicinePrice[])=>{
      this.medicineList = data;
    })

    if (this.brandId != 0)
    {
      this.service.getBrandById(this.brandId).subscribe((data: IBrand)=>{
        this.brand=data;
      })
    }
  }

  addMedicine() {
    this.brandMedicinePrice = {
      brandId: this.brandId,
      medicineId: 0,
      price: 0
    }
    this.modalTitle = "Добавление препарата";
    this.activateAddEditMedicinePriceComponent = true;
    this.editOrAdd = 1;
  }

  closeClick() {
    this.activateAddEditMedicinePriceComponent = false;
    this.refreshMedicinePriceList();
    this.editOrAdd = 0;
  }

  editClick(item: IBrandMedicinePrice) {

    this.brandMedicinePrice = item;
    this.modalTitle = "Редактирование стоимости";
    this.activateAddEditMedicinePriceComponent = true;
    this.editOrAdd = 2;
  }

  deleteBrandMedicinePrice(medicineId?: number) {
    if((medicineId !== null))
    {
      this.service.deleteBrandMedicinePrice(medicineId!, this.brandId!).subscribe((data: IBrandMedicinePrice) => {
        this.refreshMedicinePriceList();
      })
    }
  }
}