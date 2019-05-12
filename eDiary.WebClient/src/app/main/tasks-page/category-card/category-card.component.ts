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

  public openEditor(){
    this.editorOpened.emit();
    this.card.isEditing = true;
    this.focusOnEditor();
  }

  public closeEditor(){
    this.card.isEditing = false;
    this.editorClosed.emit();
  }

  public blurEditor(){
    setTimeout(() => this.categoryEditor.nativeElement.blur());
  }
  
  private focusOnEditor(){
    setTimeout(() => this.categoryEditor.nativeElement.focus());
  }
}
