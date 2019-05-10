import { Component, OnInit, Input, ElementRef, ViewChild, Output, EventEmitter } from '@angular/core';
import { CategoryCard } from 'src/shared/models/category-card.model';

@Component({
  selector: 'category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.scss']
})

export class CategoryCardComponent implements OnInit {
  @Input() card: CategoryCard;
  @Output() editorOpened: EventEmitter<any> = new EventEmitter();
  @Output() editorClosed: EventEmitter<any> = new EventEmitter();
  @ViewChild('categoryEditor') categoryEditor: ElementRef;

  constructor() { }

  ngOnInit() {
    if(this.card.isEditing){
      this.focusOnEditor();
    }
  }

  openEditor(){
    this.editorOpened.emit();
    this.card.isEditing = true;
    this.focusOnEditor();
    console.log("Editing...");
    
  }

  blurEditor(){
    setTimeout(() => this.categoryEditor.nativeElement.blur());
  }

  closeEditor(){
    // if(!this.card.name){
    //   this.card.name = "Unnamed category"
    // }
    this.card.isEditing = false;
    this.editorClosed.emit();
  }
  
  private focusOnEditor(){
    setTimeout(() => this.categoryEditor.nativeElement.focus());
  }
}
