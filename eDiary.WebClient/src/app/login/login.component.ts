import { Component, OnInit } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { AccountService } from '../services/account.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  addButtonText: string;
  accounts: AppUser[] = [];
  submitted = false;
  currentUser: AppUser;

  constructor(private router: Router, private accountService: AccountService, private translate: TranslateService) {
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

  async login(p: any){
    let result = await this.accountService.login(this.currentUser, SHA.sha512(p.value))   
    //if (result !== false){
    if(result){
      this.router.navigateByUrl('/app');
    };  
  }

  chooseLogin(user: AppUser){
    this.currentUser = user;
  }

  redirectToRegistration(){
    console.log('redirect to registration');
    
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
        data.forEach((e: { username: string; firstName: string; lastName: string; email: string; profileImage: string; profileId: number; }) => {
          this.accounts.push(
            new AppUser(
              e.username,
              null,
              new UserProfile(
                e.firstName,
                e.lastName,
                e.email,
                e.profileImage,
                e.profileId
              )
            )
          );
        }),
        (error: any) => console.error(error);
      });       
  }
}
