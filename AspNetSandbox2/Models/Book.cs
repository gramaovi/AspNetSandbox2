using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandbox2.Models
{
    [DebuggerDisplay("Title = {Title} Id = {Id}")]
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public decimal PurchasePrice { get; set; }
    }
}
