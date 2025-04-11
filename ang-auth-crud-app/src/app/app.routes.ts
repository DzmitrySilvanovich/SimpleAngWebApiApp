import { Routes } from '@angular/router';
import {StoreComponent} from "./store/store.component";


export const routes: Routes = [
    { path: "store", component: StoreComponent},

    //{ path: 'account', loadChildren: './account/account.module#AccountModule' },
    //{ path: 'store', loadChildren: './store/store.module#StoreModule' },
    //{ path: 'order', loadChildren: './order/order.module#OrderModule' }
];
