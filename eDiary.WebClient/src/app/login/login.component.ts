import { Component, OnInit, ViewChild } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  addButtonText: string;
  profiles: UserProfile[] = [];
  submitted = false;
  currentLogin: string;

  constructor(private router: Router, private authService: AuthenticationService) {
    this.addButtonText = "+";
    this.profiles = authService.getLogins();
   }

  ngOnInit() {
  }

  onSubmit(){ 
    this.submitted = true; 
  }

  validateInput(p: any):boolean{
    if (p.value !== undefined && p.value !== ""){
      return true;
    } else {
      p.placeholder="fill this field please";
      p.blur();
      return false;
    }
  }

  login(p: any){
    let operationResult = this.authService.login(this.currentLogin, p.value);
    if (operationResult){
      this.router.navigateByUrl('/app');
    };  
  }

  chooseLogin(p: any){
    this.currentLogin = `${p.firstName}.${p.lastName}`;
    console.log(this.currentLogin);
  }

  reg(){
    this.router.navigateByUrl('/registration');
  }


}
