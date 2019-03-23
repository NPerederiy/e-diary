import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as jwtDecode from 'jwt-decode';

export const TOKEN_KEY = "auth_token";

@Injectable()
export class TokenService {
    private readonly serverURI = "http://localhost:8181";
    private readonly tokenKey = "auth_token";

    constructor(private http: HttpClient) {}

    logTokens(){
        console.log("Access token: ", sessionStorage.getItem(this.tokenKey));
        console.log("Refresh token: ", localStorage.getItem(this.tokenKey));
    }

    getAccessToken(): string {
        return sessionStorage.getItem(this.tokenKey);
    }

    getRefreshToken(): string {
        return localStorage.getItem(this.tokenKey);
    }

    async refreshTokens(){
        let body: any = {};
        body.refreshToken = localStorage.getItem(this.tokenKey);
        return await this.http.post(`${this.serverURI}/api/token`, body).toPromise()
            .then((tokens: { access: string; refresh: string; }) => {
                if(tokens){
                    console.log('new tokens: ', tokens); // TODO: Remove this line 
                    this.saveTokens(tokens);
                    return true;
                }
                return false;
            })
            .catch((error: any) => {
                console.error(error);
                return false;
            });
    }

    getDecodedAccessToken(token: string): any {
        try{
            return jwtDecode(token);
        }
        catch(Error){
            return null;
        }
    }
    
    isTokenExpired(token?: string): boolean {
        if(!token) token = this.getAccessToken();
        if(!token) return true;
        
        const date = this.getTokenExpirationDate(token);
        if(date === undefined) return false;
        return !(date.valueOf() > new Date().valueOf());
    }

    saveTokens(tokens: { access: string; refresh: string; }) {
        localStorage.setItem(this.tokenKey, tokens.refresh);
        sessionStorage.setItem(this.tokenKey, tokens.access);
    }
    
    removeTokens(){
        sessionStorage.removeItem(this.tokenKey);
        localStorage.removeItem(this.tokenKey);
    }

    private getTokenExpirationDate(token: string): Date {
        const tokenInfo = jwtDecode(token);

        if (tokenInfo.exp === undefined) return null;

        const date = new Date(0); 
        date.setUTCSeconds(tokenInfo.exp);
        return date;
    }
}