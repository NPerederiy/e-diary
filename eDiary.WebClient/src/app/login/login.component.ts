import { Component, OnInit } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { AuthenticationService } from '../services/authentication.service';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  addButtonText: string;
  accounts: AppUser[] = [];
  submitted = false;
  currentLogin: string;

  constructor(private router: Router, private authService: AuthenticationService, private accountService: AccountService) {
    this.addButtonText = "+";
    this.redirectToRegisterIfNoAccountsReceived();
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

  chooseLogin(u: AppUser){
    this.currentLogin = u.username;
  }

  redirectToRegistration(){
    this.router.navigateByUrl('/registration');
  }

  private async redirectToRegisterIfNoAccountsReceived(){
    await this.loadAccounts().then(()=>{
      if(this.accounts.length === 0){
        this.redirectToRegistration();
      }
    });
  }

  private async loadAccounts(){
    await this.accountService.getAccounts().then(
      (data: any) => {
        data.forEach((e: { username: string; firstName: string; lastName: string; email: string; profileImage: string; userId: number; }) => {
          this.accounts.push(
            new AppUser(
              e.username,
              null,
              new UserProfile(
                  e.firstName,
                  e.lastName,
                  e.email,
                  e.profileImage,
                  e.userId
              )
            )
          );
        }),
        (error: any) => console.error(error);
      });       
  }
}
