import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { catchError } from 'rxjs/operators';

@Injectable()
export class RequestManagerService {
  url = "https://elibraryapi.azurewebsites.net/api/"
  constructor(private http: HttpClient) {
  }

  getAll(urlString: string) {
    return this.http.get(this.url + urlString).pipe(catchError(this.handleError));
  }

  get(path: string) {
    return this.http.get(this.url + path).pipe(catchError(this.handleError));
  }

  post(resource) {
    return this.http.post(this.url, JSON.stringify(resource)).pipe(catchError(this.handleError));
  }

  private handleError(error: Response) {
    if (error.status === 400)
      alert("400 geldi")
  
    if (error.status === 404)
      alert("Sayfa bulunamadı")
    return null;
  }
}
