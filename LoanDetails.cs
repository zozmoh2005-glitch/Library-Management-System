using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Library
{
    public class LoanDetails
    {
        [Key] public int LoanDetails_Id { get; set; }
        public int Loan_Id {  get; set; }
       [ForeignKey(nameof(Loan_Id))]
            public virtual Loan Loan { get; set; }
        public int Book_Id {  get; set; }
       [ ForeignKey(nameof(Book_Id))]
       public virtual Book Book {  get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity {  get; set; }

    }
}
