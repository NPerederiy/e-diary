import { Component, OnInit, Input } from '@angular/core';
import { Folder } from 'src/shared/models/note-folder.model';

@Component({
  selector: 'folder-page',
  templateUrl: './folder.component.html',
  styleUrls: ['./folder.component.scss']
})
export class FolderComponent implements OnInit {
  @Input() folder: Folder;
  
  scrollbarOptions = { 
    axis: 'y', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };
  
  constructor() { }
  
  ngOnInit() { }

}
