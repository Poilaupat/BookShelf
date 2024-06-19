using System.Data;

namespace BookShelfApi.Models
{
    public class Book
    {
        public long BookId { get; set; }
        public string? BookName { get; set; }

        public static Book FromRow(DataRow row)
        {
            var book = new Book();

            book.BookId = row.Field<long>("BookId");
            book.BookName = row.Field<string>("BookName");

            return book;
        }
    }
}
