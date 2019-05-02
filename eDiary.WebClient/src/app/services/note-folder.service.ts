import { Injectable } from "@angular/core";
import { UserProfileService } from "./user-profile.service";
import { UserProfile } from "src/shared/models/user-profile.model";
import { HttpClient } from "@angular/common/http";
import { Folder } from "src/shared/models/note-folder.model";
import { NoteCard } from "src/shared/models/note-card.model";

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

    public async getFolder(folderId: number): Promise<Folder>{

        // let fo: Folder;

        // return await this.http.get(`${this.serverURI}/api/folder/${folderId}`)
        //     .subscribe((f: { id: number, name: string, notes: NoteCard[], folders: Folder[], parentFolderId: number}) => {
        //         console.log('!!!!!',f);
        //         let fo = new Folder(f.notes, f.name, "", f.folders);
        //         return fo;
        //     },(error: any) => {
        //         console.error(error);
        //         return null;
        //     });

        return await this.http.get(`${this.serverURI}/api/folder/${folderId}`).toPromise()
        .then((f: { id: number, name: string, notes: NoteCard[], folders: Folder[], parentFolderId: number}) => {
            // console.log('!!!!!',f);            
            let folder = new Folder(f.notes, f.name, "/", f.folders);
            return folder;
        })
        .catch((error: any) => {
            console.error(error);
            return null;
        });


            // this.http.get(`${this.serverURI}/api/folder/${folderId}`).toPromise()
            // .then((f: { id: number, name: string, notes: NoteCard[], folders: Folder[], parentFolderId: number}) => {
            //     console.log('!!!!!',f);
            //     fo = new Folder(f.notes, f.name, "", f.folders);
                
            //     let folder = new Folder();
            //     return folder;
            // })
            // .catch((error: any) => {
            //     console.error(error);
            //     return null;
            // });

        //     let folder = r.then((f) => {return f});


        // return a;
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