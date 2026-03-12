namespace BookApi.DTOs;

public record BookDetailsDto(
    int Id, 
    string Title, 
    string Author, 
    string Isbn, 
    DateOnly PublicationDate
);