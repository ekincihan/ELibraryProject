import { Component, OnInit } from "@angular/core";
import { HeaderService } from "./shared/headerService";
import { Category } from "../models/Category";
import { Publisher } from "../models/Publisher";

import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { SigninComponent } from "../signin/signin.component";
import { SignupComponent } from "../signup/signup.component";
import { TokenService } from "../service/token.service";
import { Router } from "../../../node_modules/@angular/router";
import { LoaderService } from "../service/loader.service";
@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {
  isLogin = false;
  public bsModalRef: BsModalRef
  categories: Category[];
  publishers: Publisher[];
  user: any;

  constructor(
    private headerService: HeaderService,
    private modalService: BsModalService,
    private router: Router,
    private loaderService:LoaderService,
    private tokenService: TokenService
  ) {

    if (localStorage.getItem('token'))
      this.isLogin = true;
    this.tokenService.isLoginChange.subscribe(() => {
      this.isLogin = this.tokenService.getIsLogin();
    })

    this.user = JSON.parse(localStorage.getItem('user'));

  }

  ngOnInit() {
    this.loaderService.show();
    this.headerService.getAll("Category/List").subscribe(res => {
      this.categories = res["value"];
      this.loaderService.hide();
    });
    this.loaderService.show();
    this.headerService.getAll("Publisher/List").subscribe(rest => {
      this.publishers = rest["value"];
      this.loaderService.hide();
    });
  }

  openSignIn() {
    this.bsModalRef = this.modalService.show(SigninComponent);
  }
  openSignUp() {
    this.bsModalRef = this.modalService.show(SignupComponent);
  }

  closeApp() {
    this.tokenService.isLogin = false;
    this.tokenService.isLoginChange.emit(false);
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.router.navigate(["./index"])
  }
}
