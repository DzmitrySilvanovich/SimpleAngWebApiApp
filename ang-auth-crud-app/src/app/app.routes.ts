import { Routes } from '@angular/router';
import {StoreComponent} from "./store/store.component";
import {HomeComponent} from "./home/home.component";
import {AccountComponent} from "./account/account.component";
import { MsalGuard } from '@azure/msal-angular';


export const routes: Routes = [
    { path: "", component: HomeComponent},
    { path: "home", component: HomeComponent/*, canActivate: [MsalGuard]*/},
    { path: "store", component: StoreComponent, canActivate: [MsalGuard]},
    { path: "account", component: AccountComponent},
];
