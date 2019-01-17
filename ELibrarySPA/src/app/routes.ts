import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { BookDetailComponent } from "./book-detail/book-detail.component";
import { AuthorDetailComponent } from "./author-detail/author-detail.component";
import { CategoryComponent } from "./category/category.component";
import { CategoryDetailComponent } from "./category/category-detail/category-detail.component";
import { PublisherComponent } from "./publisher/publisher.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { BookViewerComponent } from "./book-detail/book-viewer/book-viewer.component";


export const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "kitap-detay/:bookId", component: BookDetailComponent },
  { path: "kitap-oku/:bookId", component: BookViewerComponent },
  { path: "kategoriler", component: CategoryComponent },
  { path: "kategori/detay", component: CategoryDetailComponent },
  { path: "yayinevi", component: PublisherComponent},
  { path: "yazar-detay/:authorId", component: AuthorDetailComponent },
  { path: "profil", component: UserProfileComponent }, 
  { path: "**", redirectTo: "index", pathMatch: "full" }
];
