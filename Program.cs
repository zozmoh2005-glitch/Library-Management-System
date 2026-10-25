using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace EF_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();

            void BorrowBooks(int student_id,List<(int book_id,int quantity)>books)
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("You must select at least one book");
                    return;
                }
                var student = db.Students.Find(student_id);
                if (student == null){Console.WriteLine("Student not found");return;}

                // لو فيه كتاب متكرر يوقف العمليه
                if (books.GroupBy(x => x.book_id).Any(g => g.Count() > 1))
                {
                    Console.WriteLine("Duplicate book IDs are not allowed");
                    return;
                }


                // Validation
                foreach (var item in books)
                {
                    var book = db.Books.Find(item.book_id);
                    if (book == null)
                    {
                        Console.WriteLine("Book not found");
                        return;
                    }
                    if (item.quantity <= 0)
                    {
                        Console.WriteLine("Quantity must be postive number");
                        return;
                    }
                    if (book.AvailableCopies < item.quantity)
                    {
                        Console.WriteLine($"There is {book.AvailableCopies} copies only of {book.Title} book");
                        return;
                    }
                }

                using var transaction = db.Database.BeginTransaction();

                try
                {
                    var loan = new Loan();
                    loan.Student_Id = student_id;

                    // Execution
                    foreach (var item in books)
                    {
                        var book = db.Books.Find(item.book_id);
                        var loandetails = new LoanDetails();
                        loandetails.Book_Id = book.Book_Id;
                        loandetails.Quantity = item.quantity;
                        loan.LoanDetails.Add(loandetails);
                        book.AvailableCopies -= item.quantity;
                    }


                    db.Loans.Add(loan);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            void ReturnBooks(int loan_id)
            {
                var loan=db.Loans.Find(loan_id);
                if(loan == null)
                {
                    Console.WriteLine("Loan not found");
                    return;
                }
                if (loan.IsReturned)
                {
                    Console.WriteLine("Loan is already returned");
                    return;
                }
             
                using var transaction = db.Database.BeginTransaction();
                try
                {
                    var loandetails = loan.LoanDetails;
                    foreach (var item in loandetails)
                    {
                        var book = item.Book;
                        book.AvailableCopies += item.Quantity;
                    }
                    loan.IsReturned = true;
                    db.SaveChanges();
                    transaction.Commit();
                        }
                catch { transaction.Rollback();throw; }
            }
            //var ZikaBooks = new List<(int book_id, int Quantity)>{
            // (1,2), (2,3)
            //};
            //BorrowBooks(3, ZikaBooks);

            //var ZezoBooks = new List<(int book_id, int Quantity)>{
            // (3,2), (4,3)
            //};
            //BorrowBooks(5, ZezoBooks);

            //var WezzaBooks = new List<(int book_id, int Quantity)>{
            // (4,2), (1,22)
            //};
            //BorrowBooks(6, WezzaBooks);


            ReturnBooks(1);
            ReturnBooks(1);



            //var students = new List<Student>
            //    {
            //        new Student(){Name="Zika",Age=20,Email="zika@gmail.com"},
            //        new Student(){Name="Zoz",Age=20,Email="zoz@gmail.com"},
            //        new Student(){Name="Zezo",Age=20,Email="zezo@gmail.com"},
            //        new Student(){Name="Wezza",Age=20,Email="wezza@gmail.com"},
            //        new Student(){Name="Zozy",Age=20,Email="zozy@gmail.com"},
            //        new Student(){Name="Zoza",Age=20,Email="zoza@gmail.com"},

            //    };
            //db.Students.AddRange(students);
            //db.SaveChanges();


            //   var authors = new List<Author>
            //   {
            //       new Author()
            //       {
            //           Name="Ziad Khalil",Age=40,
            //           Books=new List<Book>()
            //           {
            //               new Book(){Title="C# Sundmentals",AvailableCopies=10},
            //               new Book(){Title="Data Structures",AvailableCopies=15 }
            //           }
            //       },
            //       new Author()
            //       {
            //           Name="Ahmed Mohamed",Age=50, 
            //           Books=new List<Book>()
            //           {
            //               new Book(){Title="Egypt",AvailableCopies=10},
            //               new Book(){Title="Iraq",AvailableCopies=15 }
            //           }
            //       }
            //   };

            //   var categories = new List<Category>
            //   {
            //       new Category(){ Name="Programming"},
            //       new Category(){ Name="History", }
            //   };

            //   foreach (var book in authors[0].Books)
            //   {
            //       book.Category = categories[0];
            //   }

            //   foreach (var book in authors[1].Books)
            //   {
            //       book.Category = categories[1];
            //   }
            //   db.Authors.AddRange(authors);
            //   db.Categories.AddRange(categories);
            //   db.SaveChanges();

            // عامل الكتابين دول عشان اجرب المسح مش اكتر
            //var books = new List<Book>()
            //{
            //    new Book(){Title="First",AvailableCopies=2,Author_Id=1,Category_Id=1},
            //    new Book(){Title="Second",AvailableCopies=2,Author_Id=2,Category_Id=2},
            //};
            //db.Books.AddRange(books);
            //db.SaveChanges();

            //var ids = new List<int> { 5, 6, 7 };

            //var booksToRemove = db.Books
            //    .Where(b => ids.Contains(b.Book_Id))// where   بترجع العناصر اللي لقيتها فقط ولو ملقتش بترجع ليست فاضيه
            //                                        // لو مستخدمين find هيعمل ايرور لان معندناش id=7
            //    .ToList();

            //db.Books.RemoveRange(booksToRemove);
            //db.SaveChanges();






        }
    }
}
