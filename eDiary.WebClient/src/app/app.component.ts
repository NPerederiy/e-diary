import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { TokenService } from './services/token.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {  
  constructor(private translate: TranslateService, private router: Router, private tokenService: TokenService) {
    translate.setDefaultLang('uk');
  }

  ngOnInit(){
    if (!this.tokenService.isTokenExpired()) {
      return true;
    }
    this.router.navigate(['/login']);
  }

}
