import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IBrand } from 'src/app/interface/brand.interface';
import { IBrandMedicinePrice } from 'src/app/interface/brandMedicinePrice.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-brand-list',
  templateUrl: './brand-list.component.html',
  styleUrls: ['./brand-list.component.css']
})
export class BrandListComponent {

  constructor(private service:SharedService) {}

  brandList!: IBrand[];

  searchString: string = "";

  modalTitle!: string;

  activateAddEditBrandComponent: boolean = false;

  activateConfirmComponent: boolean = false;

  brand!: IBrand;

  brandMedicinePrice!: IBrandMedicinePrice;

  confirmId?: number;

  confirmTitle!: string;

  confirmFlag!: string;
  
  ngOnInit(): void {
    this.getBrandList();
  }

  getBrandList(){
    this.service.getAllBrand().subscribe((data: IBrand[])=>{
      this.brandList=data;
    })
  }

  getBrandListByName() {
    if (this.searchString != "") 
    {
      this.service.getBrandByName(this.searchString).subscribe((data: IBrand[]) => {
        this.brandList = data;
      })
    }
    else
    {
      this.getBrandList();
    }
  }

  deleteBrand(brandId?: number) {

    this.confirmId = brandId;

    this.confirmTitle = "Вы точно хотите удалить?"

    this.activateConfirmComponent = true;

    this.confirmFlag = "brand";

    // if((brandId !== null))
    // {
    //   // this.service.deleteBrand(brandId!).subscribe((data: IBrand) => {
    //   //   this.getBrandList();
    //   // })
    // }
  }

  addBrand() {

    this.brand = {
      brandId: 0,
      name: "",
      logo: "default.png"
    }
    this.modalTitle = "Добавление бренда";
    this.activateAddEditBrandComponent = true;
  }

  closeClick() {
    this.activateAddEditBrandComponent = false;
    this.getBrandList();
  }

  editClick(item: IBrand) {
    this.brand = item;
    this.modalTitle = "Редактирование бренда";
    this.activateAddEditBrandComponent = true;
  }
}
