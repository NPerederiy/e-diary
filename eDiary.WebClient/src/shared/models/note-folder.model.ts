import { NoteCard } from "./note-card.model";

export class Folder{
    name: string;
    path: string;
    cards: NoteCard[];
    subfolders: Folder[];

    constructor(cards?:NoteCard[], name?: string, path?: string, subfolders?: Folder[]) {
        this.name = name || "root";
        this.path = path || "root";
        this.cards = cards || [];
        this.subfolders = subfolders || [];
    }

    // TODO: make 'root' folder static
}