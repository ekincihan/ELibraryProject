import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";
import { BookDetailComponent } from "./book-detail/book-detail.component";
import { AuthorDetailComponent } from "./author-detail/author-detail.component";
import { CategoryComponent } from "./category/category.component";
import { CategoryDetailComponent } from "./category/category-detail/category-detail.component";
import { PublisherComponent } from "./publisher/publisher.component";
import { UserProfileComponent } from "./user-profile/user-profile.component";
import { BookViewerComponent } from "./book-detail/book-viewer/book-viewer.component";
import { CategoryFullComponent } from "./category/category-full/category-full.component";
import { PublisherDetailComponent } from "./publisher/publisher-detail/publisher-detail.component";
import { AuthorComponent } from "./Author/Author.component";
import { ContactComponent } from "./contact/contact.component";
import { AboutComponent } from "./footer/about/about.component";


export const appRoutes: Routes = [
  { path: "Anasayfa", component: IndexComponent },
  { path: "kitap-detay/:bookId", component: BookDetailComponent },
  { path: "kitap-oku/:bookId", component: BookViewerComponent },
  { path: "kategoriler", component: CategoryComponent },
  { path: "kategori-detay/:categoryId", component: CategoryDetailComponent },
  { path: "yayinevleri", component: PublisherComponent},
  { path: "yayinevi-detay/:publisherId", component: PublisherDetailComponent},
  { path: "yazar-detay/:authorId", component: AuthorDetailComponent },
  { path: "kategori-tumu", component: CategoryFullComponent },
  { path: "profil", component: UserProfileComponent },
  { path: "iletisim", component: ContactComponent },
  { path: "yazarlar", component: AuthorComponent },
  { path: "hakkımızda", component: AboutComponent },
  { path: "**", redirectTo: "Anasayfa", pathMatch: "full" }
];
