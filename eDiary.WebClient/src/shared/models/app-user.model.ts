export class AppUser{
    username: string;
    passwordHash: string;
    email: string;

    constructor(username: string, passwordHash: string, email?:string) {
        this.username = username;
        this.passwordHash = passwordHash;
        this.email = email || "";
    }
}