import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IBrand } from 'src/app/interface/brand.interface';
import { IMedicine } from 'src/app/interface/medicine.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-medicine-modal',
  templateUrl: './add-edit-medicine-modal.component.html',
  styleUrls: ['./add-edit-medicine-modal.component.css']
})
export class AddEditMedicineModalComponent {

  constructor(private service: SharedService) {}

  input!: FormGroup;

  @Input() medicine!: IMedicine;
  medicineId?: number;
  name!: string;
  category!: string;
  image!: string;
  instruction!: string;
  imagePath!: string;


  ngOnInit() {
    this.medicineId = this.medicine.medicineId;
    this.name = this.medicine.name;
    this.category = this.medicine.category;
    this.image = this.medicine.image;
    this.instruction = this.medicine.instruction;
  }

  addMedicine() {
    var val = {
      medicineId: this.medicineId, 
      name: this.name, 
      category: this.category, 
      image: this.image, 
      instruction: this.instruction
    }

    this.service.addMedicine(val).subscribe(res => {
    })
  }

  editMedicine() {
    var val = {
      medicineId: this.medicineId, 
      name: this.name, 
      category: this.category, 
      image: this.image, 
      instruction: this.instruction
    }

    this.service.editMedicine(val).subscribe(res => {
    })

  }

  uploadPhoto(event: any) {
    var file = event.target.files[0];

    const formData: FormData = new FormData();
    
    formData.append("file", file, file.name);

    this.service.uploadPhoto(formData).subscribe((data: any) => {
      this.image = data.name;
    })
  }
}
