import { Book } from "./Book";
import { AppFileFilter } from "./AppFileFilter";

export class Author {
  id: string;
  name: string;
  surname: string;
  biography: string;
  gender: number;
  publisherId: string;
  isActive: boolean;
  appFileFilterModel: AppFileFilter;
  books:Book[];
}
