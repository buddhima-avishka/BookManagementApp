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

  isFormVisible: boolean = false;

  constructor(private bookService: BookService) {}

  ngOnInit(): void { this.loadBooks(); }

  loadBooks() {
    this.bookService.getBooks().subscribe(data => this.books = data);
  }

  toggleForm() {
    this.isFormVisible = !this.isFormVisible;
    if (!this.isFormVisible) this.resetForm();
  }

  saveBook() {
    if (this.newBook.id === 0) {
      this.bookService.addBook(this.newBook).subscribe(() => {
        this.loadBooks();
        this.toggleForm();
      });
    } else {
      this.bookService.updateBook(this.newBook.id, this.newBook).subscribe(() => {
        this.loadBooks();
        this.toggleForm();
      });
    }
  }

  editBook(book: Book) { this.newBook = { ...book }; this.isFormVisible = true;}

  deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => this.loadBooks());
  }

  resetForm() {
    this.newBook = { id: 0, title: '', author: '', isbn: '', publicationDate: '' };
  }
}
