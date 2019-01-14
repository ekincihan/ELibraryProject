/* MODULES */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxMaskModule } from 'ngx-mask'
import { FormsModule } from '@angular/forms';
import { RatingModule } from 'ngx-bootstrap/rating';
import { SnotifyModule, SnotifyService, ToastDefaults } from 'ng-snotify';


/* COMPONENTS */
import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SearchComponent } from './index/search/search.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { NavigationComponent } from './navigation/navigation.component';
import { AuthorDetailComponent } from './author-detail/author-detail.component';
import { HeaderComponent } from './header/header.component';
import { MixedBooksComponent } from './mixed-books/mixed-books.component';
import { CategoryComponent } from './category/category.component';
import { CategoryDetailComponent } from './category/category-detail/category-detail.component';
import { PublisherComponent } from './publisher/publisher.component';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { BookViewerComponent } from './book-detail/book-viewer/book-viewer.component';

/* SERVICES */
import { IndexService } from './index/shared/index.service';
import { AuthorDetailService } from './author-detail/shared/author-detail.service';
import { MixedBooksService } from './mixed-books/shared/mixedBooksService.service';
import { HeaderService } from './header/shared/headerService';
import { PublisherService } from './publisher/shared/publisher.service';
import { UserProfileService } from './user-profile/shared/user-profile.service';

/* ROUTES */
import { appRoutes } from './routes';
import { SignUpService } from './signup/shared/signUp.service';
import { SignInService } from './signin/shared/signIn.service';
import { TokenService } from './service/token.service';
import { SearchService } from './index/shared/search.service';

import { BookService } from './book-detail/shared/book.service';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';

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
        MixedBooksComponent,
        CategoryComponent,
        CategoryDetailComponent,
        PublisherComponent,
        SigninComponent,
        SignupComponent,
        UserProfileComponent,
        BookViewerComponent
    ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forRoot(appRoutes),
        ModalModule.forRoot(),
        BsDatepickerModule.forRoot(),
        NgxMaskModule.forRoot(),
        RatingModule.forRoot(),
        NgxExtendedPdfViewerModule,
        SnotifyModule
    ],
    providers: [
        IndexService,
        AuthorDetailService,
        MixedBooksService,
        HeaderService,
        PublisherService,
        SignUpService,
        SignInService,
        TokenService,
        SearchService,
        BookService,
        UserProfileService,
        [
            { provide: 'SnotifyToastConfig', useValue: ToastDefaults },
            SnotifyService
        ]
    ],
    bootstrap: [
        AppComponent
    ],
    entryComponents: [
        SigninComponent,
        SignupComponent
    ]
})
export class AppModule { }
