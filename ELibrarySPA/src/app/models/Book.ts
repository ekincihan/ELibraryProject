import { Publisher } from "./Publisher";
import { Author } from "./Author";
import { AppFile } from "./AppFile";

export class Book {
    id:string;
    bookName:string;
    bookSummary:string;
    authorId:string;
    editionDate:Date;
    numberPage:number
    isbn:string;
    publisherId:string;
    isActive:boolean;
    publisher:Publisher;
    author:Author;
    readCount:number;
    bookPhoto:string;
    thumbnail:AppFile;
    appFiles:AppFile[];
}
