import { Injectable } from '@angular/core';
import { RequestManagerService } from 'src/app/service/RequestManager.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AuthorService extends RequestManagerService  {

constructor(http:HttpClient) {
  super(http)
 }

}
