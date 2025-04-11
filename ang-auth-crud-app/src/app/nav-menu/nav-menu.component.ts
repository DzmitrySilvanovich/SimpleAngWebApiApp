import { Component, OnInit } from '@angular/core';
import {RouterModule} from '@angular/router';
import { RouterLink, RouterOutlet, RouterLinkActive} from '@angular/router';
//import { RouterOutlet, RouterLink} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}

/*import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  imports: [],
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.css'
})
export class NavMenuComponent {

}
*/
