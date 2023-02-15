import { Component } from '@angular/core';
import { IMedicine } from 'src/app/interface/medicine.interface';

import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-show-medicine',
  templateUrl: './show-medicine.component.html',
  styleUrls: ['./show-medicine.component.css']
})
export class ShowMedicineComponent {

  constructor(private service: SharedService) { }

  medicineList!: IMedicine[];

  medicinePage!: IMedicine;

  searchString: string = "";

  category: string = "";

  medicineId?: number;

  test: boolean = false;

  tempMedicineList: IMedicine[] = [];

  categoryList: string[] = [];

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

  
}