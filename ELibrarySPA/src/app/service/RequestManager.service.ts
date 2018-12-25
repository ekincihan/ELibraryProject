import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AppConfig } from "../app.config";

@Injectable()
export class RequestManagerService {
  constructor(private http: HttpClient, private config: AppConfig) {}

  getAll() {
    this.http.get(this.config.url).pipe();
  }

  get(id: number) {
    this.http.get(this.config.url + "/id" + id);
  }

  post(resource) {
    this.http.post(this.config.url, resource);
  }
}
