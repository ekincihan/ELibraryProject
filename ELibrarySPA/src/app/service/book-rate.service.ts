import { Injectable } from "@angular/core";

@Injectable()
export class BookRateService {
    bookList: any;
    service: any;
    user = JSON.parse(localStorage.getItem('user'));
    constructor() {

    }

    setRatedBooks(ratedBooks) {
      this.bookList.forEach(book => {
        ratedBooks.forEach(ratedBook => {
            if(ratedBook["bookId"] == book["id"] || ratedBook["bookId"] == book["bookId"]){
              book["rate"] = ratedBook["rate"];
              book["ratedBookId"] = ratedBook["id"];
            }
        });
      });
    }

    getBooks(){
      if (this.user) {
        this.service.get('User/Rate/' + this.user.id).subscribe((res: any) => {
          this.setRatedBooks(res);
        })
      }
      return this.bookList;
    }
}
