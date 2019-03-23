import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppUser } from 'src/shared/models/app-user.model';
import * as SHA from 'js-sha512';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { TokenService } from './token.service';
import { AuthRequestOptions } from './authRequest';

@Injectable()
export class AccountService {

    private readonly serverURI = "http://localhost:8181";
    
    private activeAccountProfile = new BehaviorSubject({} as UserProfile);
    
    public userProfile = this.activeAccountProfile.asObservable();

    constructor(private http: HttpClient, private tokenService: TokenService) {}

    printTokens(){  // TODO: Remove this one
        this.tokenService.logTokens();
    }

    async getProfile(id: number) {   // TODO: Remove this one
        // const headers = new HttpHeaders();
        // headers.set();
        return await this.http.get(`${this.serverURI}/api/userprofiles/${id}`).toPromise();
    }

    async getAccounts() {
        return await this.http.get(`${this.serverURI}/api/userprofiles`).toPromise();
    }

    async registration(fname: string, lname: string, email: string, password: string): Promise<boolean>{
        let body: any = {};
        body.firstName = fname;
        body.lastName = lname;
        body.email = email;
        body.password = this.encode(password);        
        return await this.http.post(`${this.serverURI}/api/Registration`, body).toPromise()
            .then((tokens: { access: string; refresh: string; }) => {
                if(tokens){
                    console.log('Tokens: ', tokens); // TODO: Remove this line 
                    this.tokenService.saveTokens(tokens);
                    this.activeAccountProfile.next(new UserProfile(fname, lname, email, null));
                    return true;
                }
                return false;
            })
            .catch((error: any) => {
                console.error(error);
                return false;
            });
    }

    async authentication(user: AppUser, password: string): Promise<boolean>{
        let body: any = {};
        body.username = user.username;
        body.password = this.encode(password);
        return await this.http.post(`${this.serverURI}/api/Authentication`, body).toPromise()
            .then((tokens: { access: string; refresh: string; }) => {
                console.log('Tokens: ', tokens); // TODO: Remove this line 
                this.tokenService.saveTokens(tokens);
                this.activeAccountProfile.next(user.profile);
                return true;
            })
            .catch((error: any) => {
                console.error(error);
                return false;
            });
    }

    logout(){
        this.tokenService.removeTokens();
        this.activeAccountProfile.next(null);
    }

    private encode(pass: string): string{
        return SHA.sha512(pass);
    }
}