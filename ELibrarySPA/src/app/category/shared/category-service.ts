import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { RequestManagerService } from "src/app/service/RequestManager.service";

@Injectable({
  providedIn: "root"
})
export class CategoryService extends RequestManagerService {
  constructor(http: HttpClient) {
    super(http);
  }
}
