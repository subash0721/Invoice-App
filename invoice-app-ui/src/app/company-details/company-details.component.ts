import { Component, OnInit } from '@angular/core';
import {CompanyService} from '../company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css']
})
export class CompanyDetailsComponent implements OnInit {
  invoiceDetail:{};
  showInvoiceDetails:boolean;
  companyId:string;
  constructor(private companyService: CompanyService) {
    this.showInvoiceDetails=false;
    this.companyId="";
   }

  ngOnInit() {
    this.showInvoiceDetails=false;
  }
  getInvoiceDetails(){
    console.log("button");
    this.companyService.GetInvoiceDetails(this.companyId).then(result=>{this.invoiceDetail=result; this.showInvoiceDetails=true; console.log(this.invoiceDetail);} )
  }

}
