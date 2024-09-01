using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFModelingApp
{
    //[NotMapped]
    public class Country
    {
        //[Column("CountryId")]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public City? Capital { get; set; }
    }
}
