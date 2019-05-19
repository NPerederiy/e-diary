export class NoteCard{
    header: string;
    descr: string;
    cardStatus: string;
    creationTime: string;
    lastEditTime: string;

    constructor(header: string, descr?: string, cardStatus?: string, creationTime?:string){
        this.header = header;
        this.descr = descr || "";
        this.cardStatus = cardStatus || "Hidden";
        this.creationTime = creationTime || "01/29/19 12:11 PM";
        this.lastEditTime = this.creationTime;
    }
}