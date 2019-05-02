import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserProfile } from "src/shared/models/user-profile.model";
import { BehaviorSubject } from "rxjs";
import { UserSettingsService } from "./user-settings.service";

@Injectable()
export class UserProfileService{
    private readonly serverURI = "http://localhost:8181";
    private currentUserProfile = new BehaviorSubject({} as UserProfile);
    private readonly profileKey = "uprofile";

    public userProfile = this.currentUserProfile.asObservable();

    constructor(
        private http: HttpClient, 
        private userSettingsService: UserSettingsService
        ) {}

    public async setProfile(profile: UserProfile){
        this.updateUserProfile(profile);
        await this.userSettingsService.loadSettings(profile.profileId);
    }
    
    public updateUserProfile(profile: UserProfile){
        this.currentUserProfile.next(profile);
        sessionStorage.setItem(this.profileKey, JSON.stringify(profile));
    }

    public changeFirstName(name: string){
        this.currentUserProfile.value.firstName = name;
        this.updateProfile();
    }

    public changeLastName(name: string){
        this.currentUserProfile.value.lastName = name;
        this.updateProfile();
    }

    public changeEmail(email: string){
        this.currentUserProfile.value.email = email;
        this.updateProfile();
    }

    public changeProfileImage(image: string){
        this.currentUserProfile.value.profileImage = image;
        this.updateProfile();
    }

    private updateProfile(){
        // TODO: Implement 
    }
}