using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Library
{
    public class Category
    {
       [Key] public int Category_Id { get; set; }
        public string Name {  get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
