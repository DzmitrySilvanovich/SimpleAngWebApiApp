import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import {
  AuthenticationResult,
  EventMessage,
  EventType,
  InteractionStatus,
} from '@azure/msal-browser';
import { filter } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: [],
    imports: [CommonModule]
})
export class HomeComponent implements OnInit{
  apiResponse: string;
  loginDisplay = false;

  constructor(
   // @Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
    private authService: MsalService,
    private msalBroadcastService: MsalBroadcastService,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
     this.msalBroadcastService.msalSubject$
   /*    .pipe(
         filter((msg: EventMessage) => msg.eventType === EventType.LOGIN_SUCCESS)
       )
       .subscribe((result: EventMessage) => {
         console.log(result);
         const payload = result.payload as AuthenticationResult;
         this.authService.instance.setActiveAccount(payload.account);
       });
 
     this.msalBroadcastService.inProgress$
       .pipe(
         filter((status: InteractionStatus) => status === InteractionStatus.None)
       )
       .subscribe(() => {
         this.setLoginDisplay();
       });
       */
   }
   setLoginDisplay() {
     this.loginDisplay = this.authService.instance.getAllAccounts().length > 0;
   }
 

  sayHello(){
    console.log('sayHello before');
    this.http.get('https://localhost:7046/WeatherForecast').subscribe( resp => {
   //   this.http.get('https://localhost:7054/WeatherForecast').subscribe( resp => {
      this.apiResponse = JSON.stringify(resp)
    })
 }

 sayHello2(){
  console.log('sayHello2');
  //this.http.get('https://localhost:7046/WeatherForecast').subscribe( resp => {
    this.http.get('https://localhost:7054/WeatherForecast').subscribe( resp => {
    this.apiResponse = JSON.stringify(resp)
  })
}
}
