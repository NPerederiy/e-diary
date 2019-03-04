import { Component, OnInit } from '@angular/core';
import { AppUser } from 'src/shared/models/app-user.model';
import { Router } from '@angular/router';
import * as SHA from 'js-sha512';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl } from '@angular/forms';
import { passwordMatchingValidator } from './validators/password-matching';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  model: any = {};
  appUser: AppUser;

  constructor(private router: Router, private formBuilder: FormBuilder, private accountService: AccountService) {
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

  showPassword(e: any){
    e.type = 'text';
  }

  hidePassword(e: any){
    e.type = 'password';
  }

  onSubmit() {

    this.accountService.registration(
      this.form.controls.fname.value,
      this.form.controls.lname.value,
      this.form.controls.email.value,
      SHA.sha512(this.form.controls.passwords.get(['password']).value)
    );

    this.router.navigateByUrl('/');
  }
}
