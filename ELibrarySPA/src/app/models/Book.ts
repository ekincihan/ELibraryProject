import { Publisher } from "./Publisher";
import { Author } from "./Author";

export class Book {
    id:string;
    BookName:string;
    BookSummary:string;
    AuthorId:string;
    EditionDate:Date;
    NumberPage:number
    ISBN:string;
    PublisherId:string;
    IsActive:boolean;
    Publisher:Publisher[];
    Author:Author[];
    BookPhoto:string;
}
