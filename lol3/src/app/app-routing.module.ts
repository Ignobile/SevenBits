import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomePageComponent} from './componentes/home-page/home-page.component';
import {LoginPageComponent} from './componentes/login-page/login-page.component';
import {RegistrerPageComponent} from './componentes/registrer-page/registrer-page.component';
import {PrivadoPageComponent} from './componentes/privado-page/privado-page.component';
import {NotFoundPageComponent} from './componentes/not-found-page/not-found-page.component';
import {UserComponent} from './componentes/user/user.component';
import {AdmiComponent} from './componentes/admi/admi.component';
import {UseremailComponent} from './componentes/useremail/useremail.component';
import {PrivadoUserComponent} from './componentes/privado-user/privado-user.component';
import {AuthGuard} from './guards/auth.guard';
const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'registrar', component: RegistrerPageComponent},
  {path: 'privado', component: PrivadoPageComponent,canActivate: [AuthGuard]},
  {path: 'user', component: UserComponent},
  {path: 'admi' , component: AdmiComponent},
  {path: 'uemail', component: UseremailComponent}, 
  {path: 'privadouser', component: PrivadoUserComponent, canActivate: [AuthGuard]},
  {path: '**', component: NotFoundPageComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [UserComponent, AdmiComponent, UseremailComponent]