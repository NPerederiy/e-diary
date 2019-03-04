import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AppUser } from 'src/shared/models/app-user.model';
import * as SHA from 'js-sha512';
import { UserProfile } from 'src/shared/models/user-profile.model';

@Injectable()
export class AccountService {
    
    private activeAccount = new BehaviorSubject(AppUser);

    private serverURI = "http://localhost:8181";
    
    userAccount = this.activeAccount.asObservable();

    constructor(private http: HttpClient) {}

    async getAccounts() {
        return await this.http.get(`${this.serverURI}/api/userprofiles`).toPromise();
    }

    async registration(fname: string, lname: string, email: string, password: string){
        let body: any = {};
        body.firstName = fname;
        body.lastName = lname;
        body.email = email;
        body.password = this.encodeReg(password);        
        return await this.http.post(`${this.serverURI}/api/Registration`, body)//.toPromise()
            .subscribe((data: any) => {
            console.log('Data: ', data);
            }),
            (error: any) => {
                console.error(error);
                return false;
            };
    }

    async authentication(username: string, password: string){
        let body: any = {};
        body.username = username;
        body.password = this.encode(username, password);
        return await this.http.post(`${this.serverURI}/api/Authentication`, body).toPromise()
            .catch( error => {
                console.error(error);
                return false;
            });
    }

    private encodeReg(pass: string): string{
        return SHA.sha512(pass);
    }

    private encode(login: string, pass: string): string{
        return SHA.sha512(`${login}${pass}`);
    }
}