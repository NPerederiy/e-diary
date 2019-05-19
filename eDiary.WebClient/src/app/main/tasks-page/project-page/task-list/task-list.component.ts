import { Component, OnInit, Input, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskSection } from 'src/shared/models/task-list.model';
import { TaskService } from 'src/app/services/task.service';
import { TaskEditorComponent } from '../task-editor/task-editor.component';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {
  @Input() section: TaskSection;
  @Output() sectionEditing: EventEmitter<any> = new EventEmitter();
  @Output() sectionEdited: EventEmitter<any> = new EventEmitter();
  @Output() taskEditing: EventEmitter<TaskCard> = new EventEmitter();
  @ViewChild('headerInput') headerInput: ElementRef;

  private isNewTaskCardCreating = false;

  public editor: TaskEditorComponent;

  scrollbarOptions = { 
    axis: 'y', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor(
    private taskService: TaskService
  ) { }
  
  ngOnInit() {
    console.log(this.section);
    
    if(this.section.isEditing){
      this.focusOnEditor();
    }
  }

  /* ------ Section ------ */

  public openSectionEditor(){
    this.sectionEditing.emit();
    this.section.isEditing = true;
    this.focusOnEditor();
  }

  public closeSectionEditor(){
    this.section.isEditing = false;
    this.sectionEdited.emit();
  }

  /* ------ Task card ------ */

  public openTaskEditor(task: TaskCard){
    this.taskEditing.emit(task);
  }

  private addTask(){
    let t = new TaskCard("");
    t.isEditing = true; 
    this.section.cards.push(t);
    this.isNewTaskCardCreating = true;
  }

  private updateTask(){
    // TODO: implement
  }

  private removeTask(card: TaskCard){
    this.taskService.removeTask(card.taskId);
  }

  private saveTaskChanges(card: TaskCard){
    if(this.isNewTaskCardCreating){
      if(card.header){
        console.log(this.section);
        
        this.taskService.addTask(card.header, this.section.sectionId)
          .then((id: number) => {
            console.log('task id: ',id);
            
            card.taskId = id;
          })
      } else {
        this.section.cards.pop();
      }
      this.isNewTaskCardCreating = false; 
    } else {
      if(card.header){
        this.taskService.updateTask(card);
      }
    }
  }

  /* ------ General ------ */

  public showContextMenu(){
    console.log('right click');
  }

  public blurEditor(){
    setTimeout(() => this.headerInput.nativeElement.blur());
  }

  private focusOnEditor(){
    setTimeout(() => this.headerInput.nativeElement.focus());
  }
}
