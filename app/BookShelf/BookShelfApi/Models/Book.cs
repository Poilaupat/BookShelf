using System.Data;

namespace BookShelfApi.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }

        public static Book FromRow(DataRow row)
        {
            var book = new Book();

            book.BookId = row.Field<int>("BookId");
            book.BookName = row.Field<string>("BookName");

            return book;
        }
    }
}
