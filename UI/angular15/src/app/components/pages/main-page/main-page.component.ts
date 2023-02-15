import { Component } from '@angular/core';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent {


  constructor(private service: SharedService) { }

  medicineList!: IMedicine[];

  ngOnInit(): void {
    this.getPopularMedicine();
  }

  getPopularMedicine() {
    this.service.getPopularMedicine().subscribe((data: IMedicine[]) => {
      this.medicineList = data;
    });
  }
}
