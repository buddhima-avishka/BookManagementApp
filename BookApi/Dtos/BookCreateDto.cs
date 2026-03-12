namespace BookApi.DTOs;

public record BookCreateDto(
    string Title, 
    string Author, 
    string Isbn, 
    DateOnly PublicationDate
);