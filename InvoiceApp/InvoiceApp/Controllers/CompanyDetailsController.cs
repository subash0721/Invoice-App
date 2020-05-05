﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.BusinessLayer;
using Invoice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers
{

    [Route("CompanyDetails")]
    public class CompanyDetailsController : Controller
    {
        private readonly ICompanyDetails _companyDetailsBL;
        public CompanyDetailsController(ICompanyDetails companyDetailsBL) {
            _companyDetailsBL = companyDetailsBL;
        }
        
        [HttpPost, Route("Create")]
        public ActionResult CreateCompany([FromBody]CompanyRequest customer) {
            try
            {
                if (string.IsNullOrEmpty(customer.CompanyName))
                {
                    return BadRequest("Company name should not be empty");
                }
               var company= _companyDetailsBL.CreateCompany(customer);
                return Ok();
            }
            catch (Exception ex) {
                return BadRequest("unable to create customer");
            }
        }
    }
}