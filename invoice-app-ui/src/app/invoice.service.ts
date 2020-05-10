import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
results:{};
  constructor(private $http: Http) { 
    this.results={};
  }
  GetInvoiceDetails(invoiceId){
    let promise = new Promise((resolve, reject) => {
      let apiURL = "http://localhost:58859/Invoice/Get/"+invoiceId;
      this.$http.get(apiURL)
        .toPromise()
        .then(
          res => { // Success
            console.log(res.json());
            this.results=res.json();
            resolve(res.json());
          },
          err=>{
            reject(err);
          }
        );
    });
    return promise;
  }
}
