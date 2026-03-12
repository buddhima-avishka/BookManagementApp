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

        group.MapPut("/{id}", (int id, BookCreateDto updatedDto) => {
            var index = _books.FindIndex(b => b.Id == id);
            if (index == -1) return Results.NotFound();

            _books[index] = new Book {
                Id = id,
                Title = updatedDto.Title,
                Author = updatedDto.Author,
                Isbn = updatedDto.Isbn,
                PublicationDate = updatedDto.PublicationDate
            };
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) => {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return Results.NotFound();

            _books.Remove(book);
            return Results.NoContent();
        });

    }
}