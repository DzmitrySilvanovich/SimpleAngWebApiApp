import {Component, OnInit, TemplateRef, ViewChild} from "@angular/core";
import {NgTemplateOutlet} from "@angular/common";
import { FormsModule }   from "@angular/forms";
import {Book} from "../core/models/book.model";
import {StoreService} from "../core/services/store.service";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-store',
  standalone: true,
  imports: [NgTemplateOutlet, FormsModule],
  templateUrl: './store.component.html',
  styleUrl: './store.component.css',
  providers: [StoreService],
})
export class StoreComponent implements OnInit  {

@ViewChild("readOnlyTemplate", {static: false}) readOnlyTemplate: TemplateRef<any>|undefined;
@ViewChild("editTemplate", {static: false}) editTemplate: TemplateRef<any>|undefined;
     
editedBook: Book|null = null;
books: Array<Book>;
isNewRecord: boolean = false;
statusMessage: string = "";
apiResponse: string;
     
constructor(private service: StoreService, private http: HttpClient) {
  this.books = new Array<Book>();
}

  ngOnInit(): void {
    this.loadBooks();
  }

  private loadBooks() {
    this.service.getBooks().subscribe((data: Array<Book>) => {
      this.books = data; 
      console.log(this.books)
  });
  }

  addBook() {
    this.editedBook = { id: 0, title: '', author: ""};
    this.books.push(this.editedBook);
    this.isNewRecord = true;
  }

  editBook(book: Book) {
    this.editedBook = book;
  }

  loadTemplate(book: Book) {
    if (this.editedBook && this.editedBook.id === book.id) {
        return this.editTemplate;
    } else {
        return this.readOnlyTemplate;
    }
  }

  saveBook() {
    if (this.isNewRecord) {
      this.service.createBook(this.editedBook as Book).subscribe(_ => {
          this.statusMessage = "Data is added",
          this.loadBooks();
      });
      this.isNewRecord = false;
      this.editedBook = null;
  } else {     
      this.service.updateBook(this.editedBook as Book).subscribe(_ => {
          this.statusMessage = "Data is updated",
          this.loadBooks();
      });
      this.editedBook = null;
  }
  }

  cancel() {
    if (this.isNewRecord) {
      this.books.pop();
      this.isNewRecord = false;
  }
  this.editedBook = null;
  }

  deleteBook(book: Book) {
    this.service.deleteBook(book.id).subscribe(_ => {
      this.statusMessage = "Data is deleted",
      this.loadBooks();
  });

  }
}
