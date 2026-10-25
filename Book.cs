using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Library
{
    public class Book
    {
        [Key] public int Book_Id {  get; set; }
        public string Title { get; set; }
        public int AvailableCopies {  get; set; }
        public int Author_Id { get; set; }

        [ForeignKey(nameof(Author_Id))]
        public virtual Author Author { get; set; }
        public int Category_Id { get; set; }

        [ForeignKey(nameof(Category_Id))]
        public virtual Category Category { get; set; }

        public virtual ICollection<LoanDetails> LoanDetails { get; set; }=new List<LoanDetails>();
    }
}
