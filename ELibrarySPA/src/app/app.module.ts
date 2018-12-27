import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {appRoutes} from './routes';

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SearchComponent } from './index/search/search.component';
import { IndexNavbarComponent } from './index/index-navbar/index-navbar.component';
import { MixedBooksComponent } from './index/mixed-books/mixed-books.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';

@NgModule({
   declarations: [
      AppComponent,
      IndexComponent,
      NavbarComponent,
      FooterComponent,
      SearchComponent,
      IndexNavbarComponent,
      MixedBooksComponent,
      BookDetailComponent,
      NavigationComponent,
      AuthorDetailComponent
   ],
   imports: [
      BrowserModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
