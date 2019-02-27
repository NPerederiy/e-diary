import { Component, OnInit, Input } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { CardStatus } from 'src/shared/models/card-status.enum';
import { TaskStatus } from 'src/shared/models/task-status.enum';

@Component({
  selector: 'task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.scss']
})

export class TaskCardComponent implements OnInit {
  @Input() card: TaskCard;

  constructor() { }

  ngOnInit() {
  }

  isHidden(): boolean {
    return this.card.cardStatus === CardStatus.hidden;
  }
  
  isHot(): boolean {
    return this.card.cardStatus === CardStatus.hot;
  }
  
  isImportant(): boolean {
    return this.card.cardStatus === CardStatus.important;
  }

  isCompleted(): boolean {
    return this.card.cardStatus === CardStatus.completed;
  }

  isDeleted(): boolean {
    return this.card.cardStatus === CardStatus.deleted;
  }


}
