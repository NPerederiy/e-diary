import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NoteCard } from "src/shared/models/note-card.model";
import { CardStatus } from "src/shared/models/card-status.enum";
import { NoteFolderService } from "./note-folder.service";

@Injectable()
export class NoteService{
    private readonly serverURI = "http://localhost:8181";

    constructor(
        private http: HttpClient,
        private folderService: NoteFolderService
        ) { }

    public getNote(noteId: number): NoteCard{
        // TODO: Implement
        return null;
    }

    public createNote(parentfolderId: number, header: string){
        let note = new NoteCard(header);
        let folder = this.folderService.getFolder(parentfolderId);
        folder.cards.push(note);

        // Save folder changes
        // TODO: Send a request to API
    }

    public editNote(note: NoteCard){
        // TODO: Open note editor component
    }

    public toggleImportant(note: NoteCard){
        note.cardStatus = note.cardStatus === CardStatus.hidden ? CardStatus.important : CardStatus.hidden;
        this.setLastEditTime(note);
        this.updateNote(note);
    }

    public setHeader(note: NoteCard, header: string){
        note.header = header;
        this.setLastEditTime(note);
        this.updateNote(note);
    }

    public setDescription(note: NoteCard, descr: string){
        note.descr = descr;
        this.setLastEditTime(note);
        this.updateNote(note);
    }

    public attachLink(){
        // TODO: Implement
    }

    public removeLink(){
        // TODO: Implement
    }

    public attachFile(){
        // TODO: Implement
    }

    public removeFile(){
        // TODO: Implement
    }

    private updateNote(note: NoteCard){
        // TODO: Implement
    }

    public deleteNote(note: NoteCard){
        // TODO: Implement
    }

    private setLastEditTime(note: NoteCard){
        note.lastEditTime = Date.now().toLocaleString();
    }
}