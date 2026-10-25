using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Library
{
    [Index("Email", IsUnique = true)]
    public class Student
    {
        [Key] public int  Student_Id {  get; set; }
        public string Name { get; set; }
        public string Email {  get; set; }
        public int Age { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }= new List<Loan>();
    }
}
