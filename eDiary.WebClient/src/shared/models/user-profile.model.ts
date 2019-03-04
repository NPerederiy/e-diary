export class UserProfile{
    userId: number;
    firstName: string;
    lastName: string;
    email: string;
    userImage: string;

    constructor(fname: string, lname: string, email: string, userImg?: string, userId?: number) {
        this.userId = userId;
        this.firstName = fname;
        this.lastName = lname;
        this.email = email;
        this.userImage = userImg || "";
    }
}