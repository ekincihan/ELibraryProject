import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { BookDetailComponent } from "./book-detail/book-detail.component";
import { AuthorDetailComponent } from "./author-detail/author-detail.component";
import { CategoryComponent } from "./category/category.component";
import { CategoryDetailComponent } from "./category/category-detail/category-detail.component";
import { PublisherComponent } from "./publisher/publisher.component";


export const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "kitap-detay", component: BookDetailComponent },
  { path: "yazar-detay", component: AuthorDetailComponent },
  { path: "kategoriler", component: CategoryComponent },
  { path: "kategori/detay", component: CategoryDetailComponent },
  { path: "yayinevi", component: PublisherComponent},
  { path: "**", redirectTo: "index", pathMatch: "full" }
];
