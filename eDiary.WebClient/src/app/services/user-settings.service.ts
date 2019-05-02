import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TranslateService } from "@ngx-translate/core";
import { UserSettings } from "src/shared/models/user-settings.model";
import { BehaviorSubject } from "rxjs";

@Injectable()
export class UserSettingsService{
    private readonly serverURI = "http://localhost:8181";
    private currentUserSettings = new BehaviorSubject({} as UserSettings);
    private readonly settingsKey = "usettings"

    public userSettings = this.currentUserSettings.asObservable();


    constructor(
        private http: HttpClient, 
        private translate: TranslateService
        ) { }

    public async loadSettings(profileId: number){
        await this.http.get(`${this.serverURI}/api/settings/${profileId}`).toPromise()
            .then((s: { setttingsId: number, userId: number, language: string, rootFolderId: number }) => {
                this.changeLanguage(s.language);
                let settings = new UserSettings(s.setttingsId, s.userId, s.language, s.rootFolderId)
                this.updateUserSettings(settings);
            })
            .catch((error: any) => {
                console.error(error);
            });
    }

    public updateUserSettings(settings: UserSettings){
        this.currentUserSettings.next(settings);
        sessionStorage.setItem(this.settingsKey, JSON.stringify(settings));
    }

    public changeLanguage(languageCode: string){
        let i = this.translate.langs.indexOf(languageCode);
        if( i !== -1){
            this.translate.use(this.translate.langs[i]);
            this.currentUserSettings.value.language = this.translate.langs[i];
        }
        // this.updateSettings ???
    }

    private updateSettings(){
        // TODO: Implement
    }
}