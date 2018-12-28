export class UserProfile{
    firstName: string;
    lastName: string;
    userImage: string;

    constructor(fname: string, lname: string, userImg?:string) {
        this.firstName = fname;
        this.lastName = lname;
        this.userImage = userImg || "";
    }
}