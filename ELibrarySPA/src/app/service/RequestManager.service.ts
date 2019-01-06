import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { catchError } from 'rxjs/operators';

@Injectable()
export class RequestManagerService {
  // url = "https://elibraryapi.azurewebsites.net/api/"
  url = "http://localhost:60088/api/"

  constructor(private http: HttpClient) {
  }

  getAll(urlString: string) {
    return this.http.get(this.url + urlString).pipe(catchError(this.handleError));
  }

  get(path: string) {
    return this.http.get(this.url + path).pipe(catchError(this.handleError));

  }

  post(path,resource) {
    let headers = new HttpHeaders();
    console.log(this.url+path)
    headers = headers.append("Content-Type", "application/json");
    return this.http.post(this.url+path, JSON.stringify(resource),{headers:headers}).pipe(catchError(this.handleError));
  }

  private handleError(error: Response) {
    if (error.status === 400)
      alert("400 geldi")
  
    if (error.status === 404)
      alert("Sayfa bulunamadı")
    return null;
  }
}
