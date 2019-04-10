export class UserSettings{
    settingsId: number;
    userId: number;
    language: string;
    rootFolderId: number;

    constructor(setttingsId: number, userId: number, language: string, rootFolderId: number) {
        this.settingsId = setttingsId;
        this.userId = userId;
        this.language = language;
        this.rootFolderId = rootFolderId;
    }
}