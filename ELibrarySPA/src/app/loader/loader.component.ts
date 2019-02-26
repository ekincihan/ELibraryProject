import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoaderService, LoaderState } from '../service/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html'
})
export class LoaderComponent implements OnInit {
  loading = false;
  private subscription: Subscription;
  constructor(
          private loaderService: LoaderService
      ) { }
  ngOnInit() {
          this.subscription = this.loaderService.loaderState
              .subscribe((state: LoaderState) => {
                  this.loading = state.loading;
              });
      }
  ngOnDestroy() {
          this.subscription.unsubscribe();
      }
  }
