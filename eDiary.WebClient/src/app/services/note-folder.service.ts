import { Injectable } from "@angular/core";
import { UserProfileService } from "./user-profile.service";
import { UserProfile } from "src/shared/models/user-profile.model";
import { HttpClient } from "@angular/common/http";
import { Folder } from "src/shared/models/note-folder.model";

@Injectable()
export class NoteFolderService{
    private readonly serverURI = "http://localhost:8181";   
    private userProfile : UserProfile;

    constructor(
        private http: HttpClient,
        private userProfileService: UserProfileService
        ) {
        this.userProfileService.userProfile.subscribe(profile => this.userProfile = profile);
    }

    public getFolder(folderId: number): Folder{
        // TODO: Implement
        return null;
    }

    public createFolder(parentFolderId: number, name: string){
        // TODO: Implement
    }

    public renameFolder(folderId: number, name: string){
        // TODO: Implement
    }

    public deleteFolder(folderId: number){
        // TODO: Implement
    }
}