import { UserProfile } from "./user-profile.model";

export class AppUser{
    username: string;
    passwordHash: string;
    profile: UserProfile;

    constructor(username: string, password: string, profile?: UserProfile) {
        this.username = username;
        this.passwordHash = password;
        this.profile = profile;
    }
}