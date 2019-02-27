import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AppUser } from 'src/shared/models/app-user.model';
import * as SHA from 'js-sha512';

@Injectable()
export class AccountService {
    private appAccounts = new BehaviorSubject([] as AppUser[])
    private activeAccount = new BehaviorSubject(AppUser);

    private serverURI = "http://localhost:8181";
    
    accounts = this.appAccounts.asObservable();
    userAccount = this.activeAccount.asObservable();

    constructor(private http: HttpClient) {}

    getAccounts(){
        return this.http.get(`${this.serverURI}/api/userprofiles`);
    }

    async registration(fname: string, lname: string, email: string, password: string){
        let body: any = {};
        body.firstName = fname;
        body.lastName = lname;
        body.email = email;
        body.password = this.encodeReg(password);
        return await this.http.post(`${this.serverURI}/api/userprofiles`, body).toPromise()
            .catch( error => {
                console.error(error);
                return false;
            });
    }

    async authentication(username: string, password: string){
        let body: any = {};
        body.username = username;
        body.password = this.encode(username, password);
        return await this.http.post(`${this.serverURI}/api/userprofiles`, body).toPromise()
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