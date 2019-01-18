import { Component, OnInit, Input } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {
  @Input() cards: TaskCard[];

  constructor() {
  }

  ngOnInit() {
  }

  showContextMenu(){
    console.log('right click');
  }

  addCard(){
    if(this.cards.length === 0 || this.cards[this.cards.length-1].header !== ""){
      this.cards.push(new TaskCard(""));
    }
  }
}
