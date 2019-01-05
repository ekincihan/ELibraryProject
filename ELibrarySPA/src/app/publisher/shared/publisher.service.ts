import { Injectable } from '@angular/core';
import { RequestManagerService } from 'src/app/service/RequestManager.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PublisherService extends RequestManagerService {

constructor(http:HttpClient) { 
  super(http)
}

}
