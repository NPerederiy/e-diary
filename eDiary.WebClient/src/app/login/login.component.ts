import { Component, OnInit, ViewChild } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  headerText: string;
  subheaderText: string;
  addButtonText: string;
  authButtonText: string;
  authFormText: string;
  profiles: UserProfile[] = [];
  submitted = false;

  appUser: AppUser;
  currentLogin: string;

  constructor(private router: Router) {
    this.headerText = "eDiary";
    this.subheaderText = "Future is planned here";
    this.addButtonText = "+";
    this.authButtonText = "Log in";
    this.authFormText = "Enter your password below";
    this.profiles.push(new UserProfile("Nikita", "Perederii"));
    this.profiles.push(new UserProfile("John", "Doe"));
    this.profiles.push(new UserProfile("Jack", "Daniels"));
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

  auth(p: any){
    if (this.validateInput(p)) {
      this.appUser = new AppUser(this.currentLogin, SHA.sha512(`${this.currentLogin.split('.')[1]}${p.value}${this.currentLogin.split('.')[0]}`));
    }     
    console.log("to authenticate:", this.appUser);
  }

  temp(e: any){
    console.log(e);
  }

  // TODO: make '.' symbol unallowed to use in names
  chooseLogin(p: any){
    this.currentLogin = `${p.firstName}.${p.lastName}`;
    console.log(this.currentLogin);
  }

  reg(){
    this.router.navigateByUrl('/registration');
  }


}
