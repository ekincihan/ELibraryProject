import { Routes } from "@angular/router";
import { IndexComponent } from "./index/index.component";

export const appRoutes: Routes = [
  { path: "index", component: IndexComponent },
  { path: "**", redirectTo: "index", pathMatch: "full" }
];
