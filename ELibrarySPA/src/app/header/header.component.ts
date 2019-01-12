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


  constructor(
    private headerService: HeaderService,
    private modalService: BsModalService,
    private router: Router,
    private tokenService: TokenService
  ) {
    
    if (localStorage.getItem('token'))
      this.isLogin = true;
    this.tokenService.isLoginChange.subscribe(() => {
      this.isLogin = this.tokenService.getIsLogin();
    })

  }

  ngOnInit() {
    this.headerService.getAll("Category/List").subscribe(res => {
      this.categories = res["value"];
    });

    this.headerService.getAll("Publisher/List").subscribe(rest => {
      this.publishers = rest["value"];
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
    this.router.navigate(["./index"])
  }
}
