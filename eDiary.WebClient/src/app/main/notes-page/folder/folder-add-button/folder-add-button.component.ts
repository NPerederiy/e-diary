import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'folder-add-button',
  templateUrl: './folder-add-button.component.html',
  styleUrls: ['./folder-add-button.component.scss']
})

export class FolderAddButtonComponent implements OnInit {

  constructor() { }

  ngOnInit() { }

  onAddFolderClick(){
    console.log("add folder");
    
  }

  onAddNoteClick(){
    console.log("add note");
  }
}
