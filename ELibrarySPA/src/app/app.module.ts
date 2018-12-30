import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {appRoutes} from './routes';

import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SearchComponent } from './index/search/search.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { IndexService } from './index/shared/index.service';
import { HttpClientModule } from '@angular/common/http';
import { AuthorDetailService } from './author-detail/shared/author-detail.service';
import { HeaderComponent } from './header/header.component';
import { MixedBooksComponent } from './mixed-books/mixed-books.component';
import { MixedBooksServiceService } from './mixed-books/shared/mixedBooksService.service';
import { HeaderService } from './header/shared/headerService';

@NgModule({
   declarations: [
      AppComponent,
      IndexComponent,
      NavbarComponent,
      FooterComponent,
      SearchComponent,
      BookDetailComponent,
      NavigationComponent,
      AuthorDetailComponent,
      HeaderComponent,
      MixedBooksComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
      IndexService,
      AuthorDetailService,
      MixedBooksServiceService,
      HeaderService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
