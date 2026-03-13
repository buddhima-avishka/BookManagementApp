using BookApi.Models;

namespace BookApi.Endpoints;

public static class BookEndpoints
{
    private static List<Book> _books = new();

    public static void MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/books");

        // GET ALL BOOKS
        group.MapGet("/", () => Results.Ok(_books));

        // GET BOOK BY ID
        group.MapGet("/{id}", (int id) =>
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            return book is not null ? Results.Ok(book) : Results.NotFound();
        });

        // ADD BOOK
        group.MapPost("/", (Book book) =>
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return Results.Ok(book);
        });

        // UPDATE BOOK
        group.MapPut("/{id}", (int id, Book updatedBook) =>
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book is null)
                return Results.NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Isbn = updatedBook.Isbn;
            book.PublicationDate = updatedBook.PublicationDate;

            return Results.Ok(book);
        });

        // DELETE BOOK
        group.MapDelete("/{id}", (int id) =>
        {
            var book = _books.FirstOrDefault(b => b.Id == id);

            if (book is null)
                return Results.NotFound();

            _books.Remove(book);
            return Results.Ok();
        });
    }
}
