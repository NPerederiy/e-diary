import { Component, OnInit, Input } from '@angular/core';
import { Folder } from 'src/shared/models/note-folder.model';

@Component({
  selector: 'folder-card',
  templateUrl: './folder-card.component.html',
  styleUrls: ['./folder-card.component.scss']
})

export class FolderCardComponent implements OnInit {
  @Input() folder: Folder;

  constructor() { }

  ngOnInit() { }

}
