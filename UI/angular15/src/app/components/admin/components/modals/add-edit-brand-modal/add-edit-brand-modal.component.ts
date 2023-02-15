import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IBrand } from 'src/app/interface/brand.interface';
import { SharedService } from 'src/app/services/shared.service';

@Component({
  selector: 'app-add-edit-brand-modal',
  templateUrl: './add-edit-brand-modal.component.html',
  styleUrls: ['./add-edit-brand-modal.component.css']
})
export class AddEditBrandModalComponent {

  constructor(private service: SharedService) {}

  input!: FormGroup;

  @Input() brand!: IBrand;
  brandId?: number;
  name!: string;
  logoFileName!: string;
  logo!: string;

  ngOnInit() {
    this.brandId = this.brand.brandId;
    this.name = this.brand.name;
    this.logo = this.brand.logo;
  }

  addBrand() {
    var val = {
      brandId: this.brandId, 
      name: this.name, 
      logo: this.logo
    }

    this.service.addBrand(val).subscribe(res => {
    })
  }

  editBrand() {
    var val = {brandId: this.brandId, name: this.name, logo: this.logo}

    this.service.editBrand(val).subscribe(res => {
    })

  }

  uploadPhoto(event: any) {
    var file = event.target.files[0];

    const formData: FormData = new FormData();
    
    formData.append("file", file, file.name);

    this.service.uploadPhoto(formData).subscribe((data: any) => {
      this.logo = data.name;
    })
  }
}
