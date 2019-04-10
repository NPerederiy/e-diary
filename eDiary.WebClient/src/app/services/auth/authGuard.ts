import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { TokenService } from 'src/app/services/token.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private tokenService: TokenService) {}

  canActivate() {
    if (!this.tokenService.isTokenExpired()) {
      return true;
    }
    console.log("token has been expired");
    this.router.navigate(['/login']);
    return false;
  }
}