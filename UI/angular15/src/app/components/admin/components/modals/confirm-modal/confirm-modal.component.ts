import { Component, Input } from '@angular/core';
import { IBrand } from 'src/app/interface/brand.interface';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-confirm-modal',
  templateUrl: './confirm-modal.component.html',
  styleUrls: ['./confirm-modal.component.css']
})
export class ConfirmModalComponent {

  constructor(private service: SharedService) { }


  @Input() confirmId?: number;
  @Input() confirmFlag!: string;

  id?: number;
  flag!: string;

  ngOnInit() {
    this.id = this.confirmId;
    this.flag = this.confirmFlag;
  }

  deleteBrand() {
    this.service.deleteBrand(this.id!).subscribe((data: IBrand) => {
    })
  }

  deleteMedicine() {
    this.service.deleteMedicine(this.id!).subscribe((data: IMedicine) => {
    })
  }
}