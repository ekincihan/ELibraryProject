import { Publisher } from "./Publisher";
import { Author } from "./Author";
import { AppFile } from "./AppFile";

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
    Publisher:Publisher;
    Author:Author;
    ReadCount:number;
    BookPhoto:string;
    Thumbnail:AppFile;
    AppFiles:AppFile[];
}
