import { Book } from "./Book";
import { AppFileFilter } from "./AppFileFilter";

export class Author {
  id: string;
  Name: string;
  Surname: string;
  Biography: string;
  Gender: number;
  PublisherId: string;
  IsActive: boolean;
  AppFileFilterModel: AppFileFilter;
}
