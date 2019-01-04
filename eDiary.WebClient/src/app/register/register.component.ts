import { Component, OnInit } from '@angular/core';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { passwordMatchingValidator } from './validators/password-matching';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  model: any = {};
  headerText: string;
  subheaderText: string;
  regButtonText: string;
  regFormText: string;
  appUser: AppUser;
  showPassword: boolean = false;
  fnameText: string;
  lnameText: string;
  passText: string;
  confPassText: string;
  emailText: string;

  constructor(private router: Router, private formBuilder: FormBuilder) {
    this.headerText = "eDiary";
    this.subheaderText = "future is planned here";
    this.regFormText = "Register new user";
    this.regButtonText = "Register";

    this.fnameText = "First name";
    this.lnameText = "Last name";
    this.passText = "Password";
    this.confPassText = "Confirm password";
    this.emailText = "Email";
  }

  public form = new FormGroup({
    fname: new FormControl('', {
      validators: [
        Validators.required,
        Validators.pattern("[A-Za-zА-Яа-я]+")
      ],
      updateOn: 'blur'
    }),
    lname: new FormControl('', {
      validators: [
        Validators.required,
        Validators.pattern("[A-Za-zА-Яа-я]+")
      ],
      updateOn: 'blur'
    }),
    passwords: new FormGroup({
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(6)
      ]),
      confirmPassword: new FormControl('', [
        Validators.required
      ]),
    }, passwordMatchingValidator
    ),
    email: new FormControl('', {
      validators: [
        Validators.required,
        Validators.email
      ],
      updateOn: 'blur'
    }),
  });

  public get controls() {
    return this.form.controls;
  }

  public get passwords() {
    return this.form.controls.passwords;
  }

  ngOnInit() {
  }

  validateInput(p: any): boolean {
    if (p.value !== undefined && p.value !== "") {
      p.classList.remove("warning");
      return true;
    } else {
      p.placeholder = "Fill this field please";
      p.blur();
      p.classList.add("warning");
      return false;
    }
  }

  onSubmit() {
    console.log(this.controls);

    console.log('SUCCESS!\n\n' + JSON.stringify(this.model));
  }
}
