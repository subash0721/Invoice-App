import { Component, OnInit } from '@angular/core';
import {InvoiceService} from '../invoice.service'

@Component({
  selector: 'app-invoice-details',
  templateUrl: './invoice-details.component.html',
  styleUrls: ['./invoice-details.component.css']
})
export class InvoiceDetailsComponent implements OnInit {
  invoiceDetail:{};
  showInvoiceDetails:boolean;
  invoiceId:string;
  constructor(private invoiceService: InvoiceService) {
    this.showInvoiceDetails=false;
    this.invoiceId="";
   }

  ngOnInit() {
    this.showInvoiceDetails=false;
  }
  getInvoiceDetails(){
    console.log("button");
    this.invoiceService.GetInvoiceDetails(this.invoiceId)
    .then(result=>{this.invoiceDetail=result; this.showInvoiceDetails=true;} )
  }
}
