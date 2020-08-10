﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindApiTenta1.Models
{
    public class SupplierModel
    {
        public int SupplierID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

        //public string Region { get; set; }
        //public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }
        public string Phone { get; set; }

        //public string Fax { get; set; }

        public string HomePage { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }
    }
}