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

  private defaultLang: string;

  constructor(private translate: TranslateService, private router: Router, private tokenService: TokenService) {
    translate.addLangs(['en', 'uk', 'ru']);
    this.defaultLang = translate.langs[1];
    translate.setDefaultLang(this.defaultLang);
    translate.use(this.defaultLang);
  }

  ngOnInit(){
    if (!this.tokenService.isTokenExpired()) {
      return true;
    }
    this.router.navigate(['/login']);
  }

}
