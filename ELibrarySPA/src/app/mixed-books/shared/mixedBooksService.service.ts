import { Injectable } from '@angular/core';
import { RequestManagerService } from 'src/app/service/RequestManager.service';
import { HttpClient } from "@angular/common/http";
import { Book } from 'src/app/models/Book';

@Injectable()
export class MixedBooksService extends RequestManagerService {

constructor(http : HttpClient) {
     super(http);
 }

}
