﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanieObiektoweLab11
{
    public class InvoiceItem
    { 
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public float Ammount { get; set; }
        public float Price { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Inovoice { get; set; }
    }
}
