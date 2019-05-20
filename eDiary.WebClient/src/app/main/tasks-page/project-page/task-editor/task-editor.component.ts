import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskService } from 'src/app/services/task.service';

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

  public isCompleted(){
    return this.task.taskStatus === "Done";
  }
  
  public closeEditor(){
    this.taskEdited.emit();
  };

  private completeTask(){
    this.task.taskStatus = "Done";
    this.task.cardStatus = "Completed";
    console.log(this.task);
    this.saveChanges();    
    this.closeEditor();
  }

  private archiveTask(){
    // TODO: throw confirmation request
    // TODO: implement card archivation
    this.task.cardStatus = "Deleted"; // CardStatus.archived
    this.taskService.archiveTask(this.task.taskId);
    this.closeEditor();
  }

  private removeTask(){
    // TODO: throw confirmation request
    this.task.cardStatus = "Deleted";
    this.taskService.removeTask(this.task.taskId);
    this.closeEditor();
  }

  private saveChanges(){
    this.taskService.updateTask(this.task);
  }
}
