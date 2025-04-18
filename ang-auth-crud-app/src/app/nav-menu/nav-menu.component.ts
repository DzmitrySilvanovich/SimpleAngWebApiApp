import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet, RouterLinkActive} from '@angular/router';
import { MsalService } from '@azure/msal-angular';
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-nav-menu',
  imports: [RouterLink, RouterLinkActive, NgIf],
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(private authService: MsalService) { }

  ngOnInit() {
  }

  isLoggedIn(): boolean {
    return this.authService.instance.getActiveAccount() != null
  }
}
