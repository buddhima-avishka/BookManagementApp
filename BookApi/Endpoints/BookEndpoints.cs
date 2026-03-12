using BookApi.Models;
using BookApi.DTOs;

namespace BookApi.Endpoints;

public static class BookEndpoints
{
    private static List<Book> _books = new();

    public static void MapBookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/books");

        group.MapGet("/", () => Results.Ok(_books));

        group.MapPost("/", (BookCreateDto bookDto) => {
            var newBook = new Book {
                Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Isbn = bookDto.Isbn,
                PublicationDate = bookDto.PublicationDate
            };
            _books.Add(newBook);
            return Results.Created($"/api/books/{newBook.Id}", newBook);
        });

    }
}