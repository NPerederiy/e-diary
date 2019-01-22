import { Component, OnInit } from '@angular/core';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { MenuButton } from 'src/shared/models/menu-button.model';

@Component({
  selector: 'notes-page',
  templateUrl: './notes-page.component.html',
  styleUrls: ['./notes-page.component.scss']
})

export class NotesPageComponent implements OnInit {
  currentPath: string = "root/folder name/folder name/folder name/folder name/folder name"
  sidebarButtons: MenuButton[] = [];

  constructor() {
    this.sidebarButtons.push(new MenuButton(MenuButtonType.RecentActions));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Search));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Notifications));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.AddNote));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.AddFolder));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.TrashCan));
   }

  ngOnInit() {
  }

}
