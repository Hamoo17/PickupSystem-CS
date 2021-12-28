﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Pickup.Application.Models.ERP
{
    public partial class TbCustomersVendor
    {
        public TbCustomersVendor()
        {
            TbTransactionHeaders = new HashSet<TbTransactionHeader>();
        }

        public int Id { get; set; }
        public int? Codes { get; set; }
        public int? OtherCodes { get; set; }
        public string Type { get; set; }
        public bool? Status { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string PersonName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Mandop { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public decimal? Limeit { get; set; }
        public decimal? Discount { get; set; }
        public string TaxCard { get; set; }
        public string CommercialRecord { get; set; }
        public string TaxFile { get; set; }
        public string TaxesPositions { get; set; }
        public string AccountNo { get; set; }
        public string TaxesOffice { get; set; }
        public int? CompanyId { get; set; }

        public virtual ICollection<TbTransactionHeader> TbTransactionHeaders { get; set; }
    }
}
