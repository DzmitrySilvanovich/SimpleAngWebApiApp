import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Book} from "../models/book.model";
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private apiUrl = environment.apiConfig.uri;
  private url : string = `${this.apiUrl}/store`;

  constructor(private http: HttpClient){ }
        
    getBooks(){
      console.log(this.url);
        return this.http.get<Array<Book>>(this.url);
    }
    
    createBook(book: Book){
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
        return this.http.post<Book>(this.url, JSON.stringify(book), {headers: myHeaders}); 
    }
    updateBook(book: Book) {
       let  url = `${this.url}/${book.id}`;
        const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
       return this.http.put<Book>(url, JSON.stringify(book), {headers:myHeaders});
    }

    deleteBook(id: number){
      let  url = `${this.url}/${id}`
        return this.http.delete<Book>(url);
    }
}
