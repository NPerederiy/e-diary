import { CardStatus } from "./card-status.enum";
import { Folder } from "./note-folder.model";

export class NoteCard{
    header: string;
    descr: string;
    cardStatus: CardStatus;

    constructor(header: string, descr?: string, cardStatus?: CardStatus){
        this.header = header;
        this.descr = descr || "";
        this.cardStatus = cardStatus || CardStatus.hidden;
    }
}