import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms'
import {HttpModule} from '@angular/http'

import { AppComponent } from './app.component';
import { InvoiceDetailsComponent } from './invoice-details/invoice-details.component';
import { CompanyDetailsComponent } from './company-details/company-details.component';
import {Routes, RouterModule} from '@angular/router';

const appRoutes:Routes=[{path:'',component:InvoiceDetailsComponent},{path:'company',component:CompanyDetailsComponent}];

@NgModule({
  declarations: [
    AppComponent,
    InvoiceDetailsComponent,
    CompanyDetailsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
