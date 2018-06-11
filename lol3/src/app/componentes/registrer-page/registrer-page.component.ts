import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../servicios/auth.service';
import {Router } from '@angular/router';
import {FlashMessagesService} from 'angular2-flash-messages';
@Component({
  selector: 'app-registrer-page',
  templateUrl: './registrer-page.component.html',
  styleUrls: ['./registrer-page.component.scss']
})
export class RegistrerPageComponent implements OnInit {
  public email: string;
  public password: string;
  constructor(
    public authService: AuthService,
    public router: Router,
    public flashMessages: FlashMessagesService
  ) { }

  ngOnInit() {
  }
  onSubmitAddUser(){
    this.authService.registerUser(this.email, this.password)
    .then((res) =>{
      this.flashMessages.show('USUARIO CREADO CORRECTAMENTE.', {cssClass: 'alert-success', timeout: 4000})
      this.router.navigate(['/privado']);
    }).catch( (err) => {
      this.flashMessages.show(err.messages, {cssClass: 'alert-success', timeout: 4000})
      
    });
  }
}
