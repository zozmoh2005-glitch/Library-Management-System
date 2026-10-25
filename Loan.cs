using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Library
{
    public class Loan
    {
        [Key] public int Loan_Id{ get; set; }
       public DateTime LoanDate {  get; set; }
        public int Student_Id { get; set; }
        [ForeignKey(nameof(Student_Id))]
        public virtual Student Student {  get; set; }

        public bool IsReturned { get; set; } = false;
        public virtual ICollection<LoanDetails> LoanDetails { get; set; }= new List<LoanDetails>();
    }
}
