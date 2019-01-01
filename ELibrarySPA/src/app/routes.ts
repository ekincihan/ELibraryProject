import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { BookDetailComponent } from "./book-detail/book-detail.component";
import { AuthorDetailComponent } from "./author-detail/author-detail.component";
import { CategoryComponent } from "./category/category.component";
import { CategoryDetailComponent } from "./category/category-detail/category-detail.component";

export const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "kitap-detay", component: BookDetailComponent },
  { path: "kategoriler", component: CategoryComponent },
  { path: "kategori/detay", component: CategoryDetailComponent },
  { path: "yazar-detay/:authorId", component: AuthorDetailComponent },
  { path: "**", redirectTo: "index", pathMatch: "full" }
];
