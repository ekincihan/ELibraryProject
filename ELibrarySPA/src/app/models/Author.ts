import { Book } from "./Book";

export class Author {
    id:string;
    Name:string;
    Surname:string;
    Biography:string;
    Gender:number
    ISBN:string;
    PublisherId:string;
    IsActive:boolean;
    BookPhoto:Date;
    books:Book[];

}
