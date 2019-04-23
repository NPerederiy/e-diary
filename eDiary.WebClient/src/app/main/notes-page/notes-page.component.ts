import { Component, OnInit } from '@angular/core';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { Folder } from 'src/shared/models/note-folder.model';
import { NoteCard } from 'src/shared/models/note-card.model';
import { CardStatus } from 'src/shared/models/card-status.enum';

@Component({
  selector: 'notes-page',
  templateUrl: './notes-page.component.html',
  styleUrls: ['./notes-page.component.scss']
})

export class NotesPageComponent implements OnInit {
  currentFolder: Folder; // folder path example: "root/folder name/folder name/folder name/folder name/folder name"
  sidebarButtons: MenuButton[] = [];

  constructor() {
    this.currentFolder = new Folder([
      new NoteCard("Magic happens!", "hello world qqqqqq wwwwwww eeeeee 3333333 3333 33333 33333 333333"),
      new NoteCard("Very loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong name","good times are comin'"),
      new NoteCard("Bug detected","user profile & user settings disappears after page refreshes", CardStatus.important),
      new NoteCard("To implement","add handling of looooong folder names", CardStatus.important),
      new NoteCard("Feature","display the number of items contained in each folder", CardStatus.important),
    ]);

    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());

    for (let i = 0; i < 200; i++) {
      this.currentFolder.cards.push(
        new NoteCard(`new note (${i})`)
      );
    }

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
