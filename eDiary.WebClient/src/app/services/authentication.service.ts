import * as SHA from 'js-sha512';
import { AppUser } from 'src/shared/models/app-user.model';
import { UserProfile } from 'src/shared/models/user-profile.model';

export class AuthenticationService{
    private appUser: AppUser;
    private profiles: UserProfile[] = [];

    constructor() {
    }

    public getLogins(){
        // TODO: implement GET method

        /* dummy data */
        this.profiles.push(new UserProfile("Nikita", "Perederii"));
        this.profiles.push(new UserProfile("John", "Doe"));
        this.profiles.push(new UserProfile("Jack", "Daniels"));
        /* ---------- */

        return this.profiles;
    }

    public login(login: string, password: string): boolean{
        this.appUser = new AppUser(login, this.encode(login, password));
        console.log(this.appUser);
        // TODO: implement login POST method
        return true;
    }
    
    public register(fname: string, lname: string, password: string, email: string): boolean{
        console.log({fname, lname, password, email});
        // TODO: implement registration POST method
        return true;
    }
    
    public logout(): boolean{
        // TODO: close current session
        this.appUser = null;
        return true;
    }

    public checkAuthToken(token: any): boolean{
        // TODO: implement login token checking 
        return this.appUser !== undefined;
    }

    private encode(login: string, pass: string): string{
       return SHA.sha512(`${login.split('.')[1]}${pass}${login.split('.')[0]}`);
    }
}