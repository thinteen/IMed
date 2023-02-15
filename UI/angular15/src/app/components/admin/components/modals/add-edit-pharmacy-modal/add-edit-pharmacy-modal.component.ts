import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IPharmacy } from 'src/app/interface/pharmacy.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-pharmacy-modal',
  templateUrl: './add-edit-pharmacy-modal.component.html',
  styleUrls: ['./add-edit-pharmacy-modal.component.css']
})
export class AddEditPharmacyModalComponent {

  constructor(private service: SharedService) {}

  input!: FormGroup;

  @Input() pharmacy!: IPharmacy;
    pharmacyId?: number;
    brandId!: number;
    address!: string;
    phoneNumber!: string;

  ngOnInit() {
    this.pharmacyId = this.pharmacy.pharmacyId;
    this.brandId = this.pharmacy.brandId;
    this.address = this.pharmacy.address;
    this.phoneNumber = this.pharmacy.phoneNumber;
  }

  addPharmacy() {
    var val = {
      pharmacyId: this.pharmacyId, 
      brandId: this.brandId, 
      address: this.address, 
      phoneNumber: this.phoneNumber
    }

    this.service.addPharmacy(val).subscribe(res => {
    })
  }

  editPharmacy() {
    var val = {pharmacyId: this.pharmacyId, brandId: this.brandId, address: this.address, phoneNumber: this.phoneNumber}

    this.service.editPharmacy(val).subscribe(res => {
    })
  }
}
