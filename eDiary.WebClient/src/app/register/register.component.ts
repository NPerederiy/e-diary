import { Component, OnInit } from '@angular/core';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  headerText: string;
  subheaderText: string;
  regButtonText: string;
  regFormText: string;
  
  appUser: AppUser;

  constructor(private router: Router) {
    this.headerText = "eDiary";
    this.subheaderText = "future is planned here";
    this.regFormText = "Register new user";
    this.regButtonText = "Register";
  }
  
  ngOnInit() {
  }

  validateInput(p: any):boolean{
    if (p.value !== undefined && p.value !== ""){
      p.classList.remove("warning");
      return true;
    } else {
      p.placeholder="Fill this field please";
      p.blur();
      p.classList.add("warning");
      return false;
    }
  }

  register(f: any, l: any, p: any, e: any){
    console.log("reg ",p);
    
  }
}
