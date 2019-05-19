import { Component, OnInit, Input, ElementRef, ViewChild, EventEmitter, Output } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';

@Component({
  selector: 'task-card',
  templateUrl: './task-card.component.html',
  styleUrls: ['./task-card.component.scss']
})

export class TaskCardComponent implements OnInit {
  @Input() card: TaskCard;
  @Output() taskCreating: EventEmitter<any> = new EventEmitter();
  @Output() taskCreated: EventEmitter<any> = new EventEmitter();
  @ViewChild('cardInput') cardInput: ElementRef;

  constructor() { }

  ngOnInit() {
    if(this.card.isEditing){
      this.focusOnEditor();
    }
  }

  private openEditor(){
    this.taskCreating.emit();
    this.card.isEditing = true;
    this.focusOnEditor();
  }

  private closeEditor(){
    this.card.isEditing = false;
    this.taskCreated.emit();
  }

  private blurEditor(){
    setTimeout(() => this.cardInput.nativeElement.blur());
  }

  private focusOnEditor(){
    setTimeout(() => this.cardInput.nativeElement.focus());
  }

  private isHidden(): boolean {
    return this.card.cardStatus === "Hidden";
  }
  
  private isHot(): boolean {
    return this.card.cardStatus === "Hot";
  }
  
  private isImportant(): boolean {
    return this.card.cardStatus === "Important";
  }

  private isCompleted(): boolean {
    return this.card.cardStatus === "Completed";
  }

  private isDeleted(): boolean {
    return this.card.cardStatus === "Deleted";
  }
}
