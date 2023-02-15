import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrand } from 'src/app/interface/brand.interface';
import { IBrandPharmacy } from 'src/app/interface/brandPharmacy.interface';
import { IPharmacy } from 'src/app/interface/pharmacy.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-pharmacy-list',
  templateUrl: './pharmacy-list.component.html',
  styleUrls: ['./pharmacy-list.component.css']
})
export class PharmacyListComponent {

  brandPharmacyList!: IBrandPharmacy[];

  pharmacy!: IPharmacy;

  brand!: IBrand;

  brandId?: number;

  modalTitle!: string;

  activateAddEditPharmacyComponent: boolean = false;

  constructor(private activateRoute: ActivatedRoute, private service:SharedService) {
    this.brandId = activateRoute.snapshot.params['brandId'];
  }

  ngOnInit(): void {
    this.refreshPharmacyList();
  }

  refreshPharmacyList(){
    if (this.brandId != null)
    {
      this.service.getPharmaciesByBrandId(this.brandId).subscribe((data: IBrandPharmacy[])=>{
        this.brandPharmacyList=data;
      })

      this.service.getBrandById(this.brandId).subscribe((data: IBrand)=>{
        this.brand=data;
      })
    }
  }

  deletePharmacy(pharmacyId?: number) {
    if((pharmacyId !== null) && (confirm('Вы уверены что хотите удалить?')))
    {
      this.service.deletePharmacy(pharmacyId!).subscribe((data: IPharmacy) => {
        this.refreshPharmacyList();
      })
    }
  }

  addPharmacy() {
    this.pharmacy = {
      pharmacyId: 0,
      brandId: this.brandId!,
      address: "",
      phoneNumber: ""
    }
    this.modalTitle = "Добавление аптеки";
    this.activateAddEditPharmacyComponent = true;
  }

  closeClick() {
    this.refreshPharmacyList();
    this.activateAddEditPharmacyComponent = false;
  }

  editClick(item: IPharmacy) {
    this.pharmacy = item;
    this.modalTitle = "Редактирование аптеки";
    this.activateAddEditPharmacyComponent = true;
  }
}