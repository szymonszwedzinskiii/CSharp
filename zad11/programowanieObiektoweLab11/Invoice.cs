using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programowanieObiektoweLab11
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Customer { set; get; }
        public String Adress { set; get; }
        public float Value { set; get; }

        public ICollection<InvoiceItem> Items { get; set; }

    }
}
