import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrerPageComponent } from './componentes/registrer-page/registrer-page.component';
import { HomePageComponent } from './componentes/home-page/home-page.component';
import { NavbarComponent } from './componentes/navbar/navbar.component';
import { LoginPageComponent } from './componentes/login-page/login-page.component';
import { PrivadoPageComponent } from './componentes/privado-page/privado-page.component';
import { NotFoundPageComponent } from './componentes/not-found-page/not-found-page.component';

import {AuthService} from './servicios/auth.service';
import { AdmiComponent } from './componentes/admi/admi.component';
import {UserComponent} from './componentes/user/user.component';
@NgModule({
  declarations: [
    AppComponent,
    RegistrerPageComponent,
    HomePageComponent,
    NavbarComponent,
    LoginPageComponent,
    PrivadoPageComponent,
    NotFoundPageComponent,
    AdmiComponent,
    UserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
