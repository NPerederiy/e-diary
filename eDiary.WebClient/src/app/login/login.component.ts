import { Component, OnInit } from '@angular/core';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { AccountService } from '../services/account.service';
import { TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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
  isPasswAlertShown = false; 

  constructor(private router: Router, private accountService: AccountService, private translate: TranslateService) {
    this.addButtonText = "+";
    this.redirectToRegisterIfNoAccountsReceived();
   }

  ngOnInit() {
  }

  public onSubmit(){ 
    this.submitted = true; 
  }

  public form = new FormGroup({
    // fname: new FormControl('', {
    //   validators: [
    //     Validators.required
    //   ]
    // }),
    password: new FormControl('', [
      Validators.required,
      Validators.minLength(6)
    ])
  });

  async login(p: any){
    if(! this.form.valid) return;

    let result = await this.accountService.login(
      this.currentUser, 
      SHA.sha512(p.value)
    )

    if(result === 0){
      this.router.navigateByUrl('/');
    } else if (result === 400){
      this.isPasswAlertShown = true;
      console.log(this.isPasswAlertShown);
    }  
  }

  public chooseLogin(user: AppUser){
    this.currentUser = user;
  }

  public isPasswordType(e: HTMLInputElement){
    return e.type === 'password';
  }

  public getPasswordElement(){
    return this.form.get('password');
  }

  public showPassword(e: any){
    e.type = 'text';
  }

  public hidePassword(e: any){
    e.type = 'password';
  }

  public hidePasswordAlert(){
    this.isPasswAlertShown = false;
  }

  public redirectToRegistration(){
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
