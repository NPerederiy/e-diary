export class UserProfile{
    profileId: number;
    firstName: string;
    lastName: string;
    email: string;
    profileImage: string;

    constructor(fname: string, lname: string, email: string, profileImg?: string, profileId?: number) {
        this.profileId = profileId;
        this.firstName = fname;
        this.lastName = lname;
        this.email = email;
        this.profileImage = profileImg || "";
    }
}