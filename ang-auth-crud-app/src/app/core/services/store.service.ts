import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Book} from "../models/book.model";

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private url = "https://localhost:7054/api/store";

    constructor(private http: HttpClient){ }
        
    getBooks(){
        return this.http.get<Array<Book>>(this.url);
    }
    
    createBook(book: Book){
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
        return this.http.post<Book>(this.url, JSON.stringify(book), {headers: myHeaders}); 
    }
    updateBook(book: Book) {
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
        return this.http.put<Book>(this.url, JSON.stringify(book), {headers:myHeaders});
    }
    deleteBook(id: number){
        return this.http.delete<Book>(this.url + "/" + id);
    }
}
