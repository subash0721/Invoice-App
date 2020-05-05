using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.BusinessLayer
{
    public interface IInvoiceDetails
    {
        InvoiceRequest CreateInvoice(InvoiceRequest invoiceRequest);
    }
}
