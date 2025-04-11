import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive} from "@angular/router";
import {NavMenuComponent} from "./nav-menu/nav-menu.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, NavMenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ang-auth-crud-app';
}
