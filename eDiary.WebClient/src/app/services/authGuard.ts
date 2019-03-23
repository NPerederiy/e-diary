import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { TokenService } from './token.service';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private tokenService: TokenService) {}

  canActivate() {
    if (!this.tokenService.isTokenExpired()) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}