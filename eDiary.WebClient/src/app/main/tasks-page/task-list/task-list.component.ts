import { Component, OnInit, Input } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskList } from 'src/shared/models/task-list.model';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.scss']
})

export class TaskListComponent implements OnInit {
  @Input() list: TaskList;
  headerEditor: string;
  isEditing: boolean;
  scrollbarOptions = { 
    axis: 'y', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor() {
  }
  
  ngOnInit() {
    this.isEditing = this.list.name === "";
  }

  addCard(){
    if(this.list.cards.length === 0 || this.list.cards[this.list.cards.length-1].header !== ""){
      this.list.cards.push(new TaskCard(""));
    }
    console.log("actual list: ",this.list);    
  }

  showContextMenu(){
    console.log('right click');
  }

  openHeaderEditor(){
    this.isEditing = true;
    this.headerEditor = this.list.name;
  }

  updateHeader(){    
    if(this.isEmpty(this.headerEditor)){
      if(this.list.cards.length == 0) { 
        /* throw event: to delete this list */ 
        console.log("throw event")
        return;
      } else { 
        /* show alert */ 
        console.log("alert")
        return;
      }
    } 
    if(this.isContainNotAllowedSigns(this.headerEditor)){ /* show alert */ return; }
    
    this.list.name = this.headerEditor;
    this.isEditing = false;
  }

  private isContainNotAllowedSigns(s: string): boolean{
    // if(s[0] === " ") return true;
    return false;
  }

  private isEmpty(s:string):boolean {
    return s === "";
  }

}
