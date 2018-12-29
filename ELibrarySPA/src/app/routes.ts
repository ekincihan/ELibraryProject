import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { BookDetailComponent } from "./book-detail/book-detail.component";
import { AuthorDetailComponent } from "./author-detail/author-detail.component";

export const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "kitap-detay", component: BookDetailComponent },
  { path: "yazar-detay", component: AuthorDetailComponent },
  { path: "**", redirectTo: "index", pathMatch: "full" }
];
