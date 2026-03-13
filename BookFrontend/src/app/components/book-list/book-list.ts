import { Component, OnInit } from '@angular/core';
import { Book } from '../../models/book';
import { BookService } from '../../services/book.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-book-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book-list.html',
  styleUrl: './book-list.css',
})
export class BookList implements OnInit {
  books: Book[] = [];
  newBook: Book = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };

  constructor(private bookService: BookService) {}

  ngOnInit(): void { this.loadBooks(); }

  loadBooks() {
    this.bookService.getBooks().subscribe(data => this.books = data);
  }

  saveBook() {
    if (this.newBook.id === 0) {
      this.bookService.addBook(this.newBook).subscribe(() => {
        this.loadBooks();
        this.resetForm();
      });
    } else {
      this.bookService.updateBook(this.newBook.id, this.newBook).subscribe(() => {
        this.loadBooks();
        this.resetForm();
      });
    }
  }

  editBook(book: Book) { this.newBook = { ...book }; }

  deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => this.loadBooks());
  }

  resetForm() {
    this.newBook = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
  }
}
