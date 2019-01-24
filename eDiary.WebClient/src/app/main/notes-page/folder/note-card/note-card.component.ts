import { Component, OnInit, Input } from '@angular/core';
import { CardStatus } from 'src/shared/models/card-status.enum';
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
    return this.card.cardStatus === CardStatus.hidden;
  }
  
  isImportant(): boolean {
    return this.card.cardStatus === CardStatus.important;
  }
  
  isDeleted(): boolean {
    return this.card.cardStatus === CardStatus.deleted;
  }
}
