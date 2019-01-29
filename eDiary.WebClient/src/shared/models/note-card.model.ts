import { CardStatus } from "./card-status.enum";
import { Folder } from "./note-folder.model";

export class NoteCard{
    header: string;
    descr: string;
    cardStatus: CardStatus;
    creationTime: string;
    lastEditTime: string;

    constructor(header: string, descr?: string, cardStatus?: CardStatus, creationTime?:string){
        this.header = header;
        this.descr = descr || "";
        this.cardStatus = cardStatus || CardStatus.hidden;
        this.creationTime = creationTime || "01/29/19 12:11 PM";
        this.lastEditTime = this.creationTime;
    }
}