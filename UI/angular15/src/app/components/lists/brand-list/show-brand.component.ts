import { Component } from '@angular/core';
import { IBrand } from 'src/app/interface/brand.interface';

import {SharedService} from 'src/app/services/shared.service';

@Component({
  selector: 'app-show-brand',
  templateUrl: './show-brand.component.html',
  styleUrls: ['./show-brand.component.css']
})
export class ShowBrandComponent {

  constructor(private service:SharedService) {}

  brandList!: IBrand[];

  searchString: string = "";

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
}