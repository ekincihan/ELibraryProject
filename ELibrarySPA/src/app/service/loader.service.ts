import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

export interface LoaderState {
  loading: boolean;
}

@Injectable()
export class LoaderService {
private loaderSubject = new Subject<LoaderState>();
loaderState = this.loaderSubject.asObservable();
constructor() {
}
show() {
        this.loaderSubject.next(<LoaderState>{loading: true});
    }
hide() {
        this.loaderSubject.next(<LoaderState>{loading: false});
    }
}
