import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  fname: string;
  lname: string;

  constructor() { 
    this.fname = "Nikita";
    this.lname = "Perederii";
  }

  ngOnInit() {
  }

}
