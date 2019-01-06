import { Component, OnInit } from "@angular/core";
import { HeaderService } from "./shared/headerService";
import { Category } from "../models/Category";
import { Publisher } from "../models/Publisher";

import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { SigninComponent } from "../signin/signin.component";
import { SignupComponent } from "../signup/signup.component";
@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {
  constructor(
    private headerService: HeaderService,
    private modalService: BsModalService
  ) { }
  public bsModalRef: BsModalRef
  categories: Category[];
  publishers: Publisher[];

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
}
