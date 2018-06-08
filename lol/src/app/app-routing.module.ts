import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {HomePageComponent} from './componentes/home-page/home-page.component';
import {LoginPageComponent} from './componentes/login-page/login-page.component';
import {RegistrerPageComponent} from './componentes/registrer-page/registrer-page.component';
import {PrivadoPageComponent} from './componentes/privado-page/privado-page.component';
import {NotFoundPageComponent} from './componentes/not-found-page/not-found-page.component';

const routes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'login', component: LoginPageComponent},
  {path: 'registrar', component: RegistrerPageComponent},
  {path: 'privado', component: PrivadoPageComponent,},
  {path: '**', component: NotFoundPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
