import { Component, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IBrandMedicinePrice } from 'src/app/interface/brandMedicinePrice.interface';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { IMedicinePrice } from 'src/app/interface/medicinePrice.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-medicine-price-modal',
  templateUrl: './add-edit-medicine-price-modal.component.html',
  styleUrls: ['./add-edit-medicine-price-modal.component.css']
})
export class AddEditMedicinePriceModalComponent {


  tempBrandId?: number;

  constructor(private activateRoute: ActivatedRoute, private service: SharedService) {
    this.tempBrandId = activateRoute.snapshot.params['brandId'];
  }

  input!: FormGroup;

  medicineName: string = "";

  medicineListByName!: IMedicine[];

  medicineList!: IMedicine[];

  tempMedicineId?: number;

  editMedicineId?: number;

  editAdd?: number;

  @Input() medicineIdForEdit?: number;
  @Input() brandMedicinePrice!: IBrandMedicinePrice;
  @Input() editOrAdd?: number;

  brandId?: number;
  medicineId?: number;
  price!: number;


  ngOnInit() {
    this.editAdd = this.editOrAdd,
    this.editMedicineId = this.medicineIdForEdit,
    this.brandId = this.brandMedicinePrice.brandId,
    this.medicineId = this.brandMedicinePrice.medicineId,
    this.price = this.brandMedicinePrice.price,

    this.getAllMedicines();

    this.input = new FormGroup({
      'price': new FormControl('', [Validators.required]),
    });
  }

  getMedicineListByName() {
    if (this.medicineName != '') 
    {
      this.service.getMedicineByName(this.medicineName).subscribe((data: IMedicine[]) => {
        this.tempMedicineId = data[0].medicineId;
      })
    };
  }

  addMedicine() {
    var val = {
      brandId: this.brandId, 
      medicineId: this.tempMedicineId, 
      price: this.price
    }

    this.service.addMedicinePriceForBrand(val).subscribe(res => {
    })
  }

  editMedicine() {
    var val = {
      brandId: this.tempBrandId, 
      medicineId: this.medicineId, 
      price: this.price
    }

    this.service.editBrandMedicinePrice(val).subscribe(res => {

    })
  }

  getAllMedicines() {
    this.service.getAllMedicine().subscribe((data: IMedicine[])=>{
      this.medicineList=data;
    })
  }

}
