using EFModelingApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWelcomeApp
{
    //[Table("Employees")]
    //[Index("Name", IsUnique = false, IsDescending = [true], Name = "NameIndex")]
    
    [EntityTypeConfiguration(typeof(EmployeeConfiguration))]
    public class Employee
    {
        //[Column("Id")]
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public string PassportSeries { get; set; } = null!;
        //public string PassportNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Company? Company { get; set; }
        public Position? Position { get; set; }

        public string? FullData { get; }

        //[NotMapped]
        //[Required]
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; } = 16000.0M;
        
        //[MaxLength(20)]
        //[MinLength(3)]
        public string? Phone { get; set; }

        public bool Activity { get; set; } = true;

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {BirthDate.ToString()}";
        }
    }
}
