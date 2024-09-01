using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelingApp
{
    public class Company
    {
        //string title;
        //Country? country;
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public Country? Country {  get; set; }

        //public string CompanyTitle
        //{
        //    get => title;
        //    set => title = value;
        //}
        //public Country? CompanyCountry 
        //{
        //    get => country;
        //    set => country = value;
        //}
        //public Company(string title = "") => this.title = title;

    }
}
