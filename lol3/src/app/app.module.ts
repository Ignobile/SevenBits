import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrerPageComponent } from './componentes/registrer-page/registrer-page.component';
import { HomePageComponent } from './componentes/home-page/home-page.component';
import { NavbarComponent } from './componentes/navbar/navbar.component';
import { LoginPageComponent } from './componentes/login-page/login-page.component';
import { PrivadoPageComponent } from './componentes/privado-page/privado-page.component';
import { NotFoundPageComponent } from './componentes/not-found-page/not-found-page.component';

import {AngularFireModule} from 'angularfire2';
import {AngularFireAuthModule} from 'angularfire2/auth';
import {environment} from '../environments/environment';

import {AuthService} from './servicios/auth.service';
import { AdmiComponent } from './componentes/admi/admi.component';
import {UserComponent} from './componentes/user/user.component';
import { UseremailComponent } from './componentes/useremail/useremail.component';
import {AuthGuard} from './guards/auth.guard';

import {FlashMessagesModule} from 'angular2-flash-messages';
import {FlashMessagesService} from 'angular2-flash-messages';
import { PrivadoUserComponent } from './componentes/privado-user/privado-user.component';

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
    UseremailComponent,
    PrivadoUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    AngularFireAuthModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    FlashMessagesModule
  ],
  providers: [AuthService, AuthGuard, FlashMessagesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
