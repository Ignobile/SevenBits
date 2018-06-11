import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../servicios/auth.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(
    public authService: AuthService,
    public router: Router,
  ) { }

  ngOnInit() {
  }
  onClickFacebookLogin(){
    this.authService.loginFacebook()
    .then((res) => {
      this.router.navigate(['/privadouser']);
    }).catch(err => console.log(err.message));
  }

}
