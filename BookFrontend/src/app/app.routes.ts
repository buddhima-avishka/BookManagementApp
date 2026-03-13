import { Routes } from '@angular/router';
import { BookList } from './components/book-list/book-list';

export const routes: Routes = [
  // Site eka load weddi kelinma poth list ekata yanna ona nam meka danna
  { path: '', redirectTo: 'books', pathMatch: 'full' },

  // Poth list ekata thiyena path eka
  { path: 'books', component: BookList },
];
