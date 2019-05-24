import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AppUser } from 'src/shared/models/app-user.model';
import * as SHA from 'js-sha512';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { TokenService } from './token.service';
import { TranslateService } from '@ngx-translate/core';
import { UserProfileService } from './user-profile.service';
import { Router } from '@angular/router';

@Injectable()
export class AccountService {
    private readonly serverURI = "http://localhost:8181";

    constructor(
        private http: HttpClient, 
        private tokenService: TokenService, 
        private userProfileService: UserProfileService, 
        private translate: TranslateService,
        private router: Router
        ) {}

    public async getAccounts() {
        return await this.http.get(`${this.serverURI}/api/userprofiles`).toPromise();
    }

    public async register(fname: string, lname: string, email: string, password: string): Promise<boolean>{
        let body: any = {};
        body.firstName = fname;
        body.lastName = lname;
        body.email = email;
        body.password = this.encode(password);      
        body.language = this.translate.currentLang;  
        return await this.http.post(`${this.serverURI}/api/Registration`, body).toPromise()
            .then(async (tokens: { access: string; refresh: string; }) => {
                let a = await this.saveTokensAndProfile(tokens, new UserProfile(fname, lname, email, null));
                return a === 0;
            })
            .catch((error: any) => {
                console.error(error);
                return false;
            });
    }

    public async login(user: AppUser, password: string): Promise<number>{
        let body: any = {};
        body.username = user.username;
        body.password = this.encode(password);
        return await this.http.post(`${this.serverURI}/api/Authentication`, body).toPromise()
            .then(async (tokens: { access: string; refresh: string; }) => {
                return await this.saveTokensAndProfile(tokens, user.profile);
            })
            .catch((error: HttpErrorResponse) => {
                return error.status;
            });
    }

    public async logout(){
        sessionStorage.clear();
        this.tokenService.removeTokens();
        // await this.userProfileService.setProfile(null);
        this.router.navigateByUrl('/login');
    }

    private async saveTokensAndProfile(tokens: { access: string; refresh: string; }, profile: UserProfile): Promise<number>{
        if(tokens){
            this.tokenService.saveTokens(tokens);
            profile.profileId = this.tokenService.getDecodedAccessToken(tokens.access)["profileId"];
            await this.userProfileService.setProfile(profile);
            return 0;
        }
        return 1;
    }

    private encode(pass: string): string{
        return SHA.sha512(pass);
    }
}