import { Component, OnInit, ViewChild } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
// import { trigger, state, style, transition, animate } from '@angular/animations';
import { AppUser } from 'src/shared/models/app-user.model';
import * as SHA from 'js-sha512';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  // animations: [
  //   trigger('slideInOut', [
  //     state('in', style({
  //       overflow: 'hidden',
  //       height: '*',
  //       width: '*'
  //     })),
  //     state('out', style({
  //       overflow: 'hidden',
  //       height: '140px',
  //       width: '*'
  //     })),
  //     transition('in => out', animate('400ms ease-in-out')),
  //     transition('out => in', animate('400ms ease-in-out'))
  //   ])
  // ]
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
  // helpMenuOpen: string;

  constructor() {
    this.headerText = "eDiary";
    this.subheaderText = "future is planned here";
    this.addButtonText = "+";
    this.authButtonText = "Log in";
    this.authFormText = "Enter your password below";
    this.profiles.push(new UserProfile("Nikita", "Perederii"));
    this.profiles.push(new UserProfile("John", "Doe"));
    this.profiles.push(new UserProfile("Jack", "Daniels"));
   }

  ngOnInit() {
    // this.helpMenuOpen = 'in';
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
    console.log("reg");
    // this.isLoginChecked = !this.isLoginChecked;
    // this.helpMenuOpen = this.helpMenuOpen === 'out' ? 'in' : 'out';
    // console.log(this.helpMenuOpen);
  }


}
