import { Component, OnInit, Input } from '@angular/core';
import { NoteCard } from 'src/shared/models/note-card.model';

@Component({
  selector: 'note-card',
  templateUrl: './note-card.component.html',
  styleUrls: ['./note-card.component.scss']
})
export class NoteCardComponent implements OnInit {
  @Input() card: NoteCard;

  constructor() { }

  ngOnInit() {
  }

  isDefault(): boolean {
    return this.card.cardStatus === "Hidden";
  }
  
  isImportant(): boolean {
    return this.card.cardStatus === "Important";
  }
  
  isDeleted(): boolean {
    return this.card.cardStatus === "Deleted";
  }
}
