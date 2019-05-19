import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskService } from 'src/app/services/task.service';
import { TaskStatus } from 'src/shared/models/task-status.enum';
import { CardStatus } from 'src/shared/models/card-status.enum';

@Component({
  selector: 'task-editor',
  templateUrl: './task-editor.component.html',
  styleUrls: ['./task-editor.component.scss']
})

export class TaskEditorComponent implements OnInit {
  @Input() task: TaskCard;
  @Output() taskEdited: EventEmitter<any> = new EventEmitter();

  constructor(
    private taskService: TaskService
  ) { }

  ngOnInit() { 
    console.log(this.task);
  }

  public closeEditor(){
    this.taskEdited.emit();
  };

  private completeTask(){
    this.task.taskStatus = TaskStatus.done;
    this.task.cardStatus = CardStatus.completed;
    console.log(this.task);
    this.saveChanges();    
    this.closeEditor();
  }

  private archiveTask(){
    // TODO: throw confirmation request
    // TODO: implement card archivation
    this.task.cardStatus = CardStatus.deleted; // CardStatus.archived
    this.taskService.archiveTask(this.task.taskId);
    this.closeEditor();
  }

  private removeTask(){
    // TODO: throw confirmation request
    this.task.cardStatus = CardStatus.deleted;
    this.taskService.removeTask(this.task.taskId);
    this.closeEditor();
  }

  private saveChanges(){
    this.taskService.updateTask(this.task);
  }

  private isCompleted(){
    return this.task.taskStatus === TaskStatus.done;
  }
}
