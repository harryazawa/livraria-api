import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Book } from './model/Book';

@Injectable()
export class BooksService {
  private url = 'https://localhost:7142/api/livraria';

  httpOptions = {
    Headers: new HttpHeaders({ 'content-type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getBook() {
    return this.http.get(this.url);
  }
}
