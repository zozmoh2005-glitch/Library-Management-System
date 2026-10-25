using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EF_Library
{
    public class Author
    {
        [Key] public int Author_Id {  get; set; }
        public string Name {  get; set; }
        public int Age {  get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
