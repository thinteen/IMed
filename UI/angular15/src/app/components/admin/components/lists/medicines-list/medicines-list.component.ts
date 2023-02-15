import { Component } from '@angular/core';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-medicines-list',
  templateUrl: './medicines-list.component.html',
  styleUrls: ['./medicines-list.component.css']
})
export class MedicinesListComponent {

  constructor(private service: SharedService) { }

  medicineList!: IMedicine[];

  searchString: string = "";
  
  category: string = "";

  tempMedicineList: IMedicine[] = [];

  categoryList: string[] = [];

  modalTitle!: string;

  activateAddEditMedicineComponent: boolean = false;

  medicine!: IMedicine;

  confirmId?: number;

  confirmTitle!: string;

  activateConfirmComponent: boolean = false;

  confirmFlag!: string;

  ngOnInit(): void {
    this.getMedicineList();
  }

  getMedicineList() {
    this.service.getAllMedicine().subscribe((data: IMedicine[]) => {
      this.medicineList = data;
      this.tempMedicineList = data;

      this.tempMedicineList.forEach(item => {
        if (this.categoryList.indexOf(item.category) == -1)
        {
          this.categoryList.push(item.category);
        }
      });
    })
  }

  getMedicineListByCategory() {
    if (this.category != "") 
    {
      this.service.getMedicineByCategory(this.category).subscribe((data: IMedicine[]) => {
        this.medicineList = data;
      })
    }

    if (this.category == "Категория")
    {
      this.getMedicineList();
    }

  }

  getMedicineListByName() {
    if (this.searchString != "") 
    {
      this.service.getMedicineByName(this.searchString).subscribe((data: IMedicine[]) => {
        this.medicineList = data;
      })
    }
    else
    {
      this.getMedicineList();
    }

    // if ((this.searchString != "") && (this.category != ""))  
    // {
    //   this.service.getMedicineByNameWithCategory(this.category, this.searchString).subscribe((data: IMedicine[]) => {
    //     this.medicineList = data;
    //   })
    // }
    // else
    // {
    //   this.getMedicineList();
    // }
  }

  deleteMedicine(medicineId?: number) {
    // console.log(medicineId);
    // if((medicineId !== null) && (confirm('Вы уверены что хотите удалить?')))
    // {
    //   this.service.deleteMedicine(medicineId!).subscribe((data: IMedicine) => {
    //     this.getMedicineList();
    //   })
    // }

    this.confirmId = medicineId;

    this.confirmTitle = "Вы точно хотите удалить?"

    this.activateConfirmComponent = true;

    this.confirmFlag = "medicine";
  }

  addMedicine() {

    this.medicine = {
      medicineId: 0,
      name: "",
      category: "",
      image: "default.png",
      instruction: "",
    }
    this.modalTitle = "Добавление препарата";
    this.activateAddEditMedicineComponent = true;
  }

  closeClick() {
    this.activateAddEditMedicineComponent = false;
    this.getMedicineList();
  }

  editClick(item: IMedicine) {
    this.medicine = item;
    this.modalTitle = "Редактирование препарата";
    this.activateAddEditMedicineComponent = true;

  }
}