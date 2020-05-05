using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoice.BusinessLayer;
using Invoice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApp.API.Controllers
{
    [Route("Invoice")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceDetails _invoiceDetailsBL;
        public InvoiceController(IInvoiceDetails invoiceDetailsBL)
        {
            _invoiceDetailsBL = invoiceDetailsBL;
        }

        [HttpPost, Route("Create")]
        public ActionResult CreateInvoice([FromBody]InvoiceRequest invoice)
        {
            try
            {
                if (invoice.CompanyID > 0)
                {
                    return BadRequest("Company ID invalid");
                }
                var company = _invoiceDetailsBL.CreateInvoice(invoice);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("unable to create customer");
            }
        }
    }
}