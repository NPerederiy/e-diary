import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskList } from 'src/shared/models/task-list.model';

interface ITaskListEditor{
  value: string;
  list: TaskList;
  hasContent(): boolean;
  saveChanges(): void;
}

class HeaderEditor implements ITaskListEditor{
  value: string;
  list: TaskList;
  constructor(list: TaskList) {
    this.value = list.name;
    this.list = list;
  }

  hasContent(): boolean{
    return this.list.cards.length !== 0;
  }

  saveChanges(){
    this.list.name = this.value;
  }
}

class CardCreator implements ITaskListEditor{
  value: string;
  list: TaskList;

  constructor(list: TaskList) {
    this.value = "";
    this.list = list;
  }

  hasContent(): boolean{
    return false;
  }
  
  saveChanges(){
    this.list.cards.push(new TaskCard(this.value));
  }
}

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {
  @Input() list: TaskList;
  @ViewChild('headerInput') headerInput: ElementRef;
  @ViewChild('cardInput') cardInput: ElementRef;
  headerEditor: ITaskListEditor;
  cardCreator: ITaskListEditor;

  scrollbarOptions = { 
    axis: 'y', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor() {
    this.headerEditor = null;
    this.cardCreator = null;
  }
  
  ngOnInit() {
    if(this.isEmpty(this.list.name)){
      this.headerEditor = new HeaderEditor(this.list);
      setTimeout(() => this.headerInput.nativeElement.focus());
    }
  }

  openCardCreator(){
    this.cardCreator = new CardCreator(this.list);
    setTimeout(() => this.cardInput.nativeElement.focus());
  }

  openHeaderEditor(){
    // if(this.list.cards.length !== 0 || !this.isEmpty(this.list.name)){
    this.headerEditor = new HeaderEditor(this.list);
    setTimeout(() => this.headerInput.nativeElement.focus());
    // }
  }

  closeEditor(editor: ITaskListEditor){
    if(this.isEmpty(editor.value)){
      if(editor.hasContent()){
        console.log("this field can't be empty");
        // throw alert
      } else {
        console.log("case 1: no changes made");
        this.closeAllEditors()
      }
    } else {
      if(this.isContainNotAllowedSigns(editor.value)){
        console.log("this field contains not allowed signs");
        // throw alert
      } else {
        console.log("case 2: changes saved");
        
        editor.saveChanges();
        this.closeAllEditors()
        console.log(this.list);
      }
    }
  }

  showContextMenu(){
    console.log('right click');
  }

  cardInputBlur(){
    setTimeout(() => this.cardInput.nativeElement.blur());
  }

  headerInputBlur(){
    setTimeout(() => this.headerInput.nativeElement.blur());
  }

  private closeAllEditors(){
    this.headerEditor = null;
    this.cardCreator = null;
  }

  private isContainNotAllowedSigns(s: string): boolean{
    return false;
  }

  private isEmpty(s: string): boolean {
    return s === "";
  }

}
