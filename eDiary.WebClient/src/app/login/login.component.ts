import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  header: string;
  subheader: string;
  addButton: string;

  constructor() {
    this.header = "eDiary";
    this.subheader = "future is built here";
    this.addButton = "+"
   }

  ngOnInit() {
  }

}
