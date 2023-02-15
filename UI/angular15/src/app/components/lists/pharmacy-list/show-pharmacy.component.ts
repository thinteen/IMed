import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IBrand } from 'src/app/interface/brand.interface';
import { IBrandPharmacy } from 'src/app/interface/brandPharmacy.interface';
import { IPharmacy } from 'src/app/interface/pharmacy.interface';

import {SharedService} from 'src/app/services/shared.service';

@Component({
  selector: 'app-show-pharmacy',
  templateUrl: './show-pharmacy.component.html',
  styleUrls: ['./show-pharmacy.component.css']
})
export class ShowPharmacyComponent {

  brandPharmacyList!: IBrandPharmacy[];

  brand!: IBrand;

  brandId?: number;

  constructor(private activateRoute: ActivatedRoute, private service:SharedService) {
    this.brandId = activateRoute.snapshot.params['brandId'];
  }

  ngOnInit(): void {
    this.refreshPharmacyList();
  }

  refreshPharmacyList(){
    if (this.brandId != 0)
    {
      this.service.getPharmaciesByBrandId(this.brandId).subscribe((data: IBrandPharmacy[])=>{
        this.brandPharmacyList=data;
      })

      this.service.getBrandById(this.brandId).subscribe((data: IBrand)=>{
        this.brand=data;
      })
    }
  }
}