import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../servicios/auth.service';
import {Router} from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';


@Component({
  selector: 'app-useremail',
  templateUrl: './useremail.component.html',
  styleUrls: ['./useremail.component.scss']
})
export class UseremailComponent implements OnInit {
  public email: string;
  public password: string;

  constructor(
    public authService: AuthService,
    public router: Router,
    public flashMessages: FlashMessagesService
  ) { }

  ngOnInit() {
  }
  onSubmitLogin(){
    this.authService.loginEmail(this.email, this.password)
    .then((res) =>{
      this.flashMessages.show('USUARIO CORRECTAMENTE INCRESADO.', {cssClass: 'alert-success', timeout: 4000})
      
      this.router.navigate(['/privadouser']);
    }).catch((err) =>{
      this.flashMessages.show('USUARIO O CONTRASEÑA INCORRECTA.', {cssClass: 'alert-danger', timeout: 4000})
      this.router.navigate(['/login']);
    });
  }

}
