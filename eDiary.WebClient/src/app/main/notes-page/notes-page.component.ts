import { Component, OnInit, Input } from '@angular/core';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { Folder } from 'src/shared/models/note-folder.model';
import { NoteCard } from 'src/shared/models/note-card.model';
import { UserProfileService } from 'src/app/services/user-profile.service';
import { UserSettingsService } from 'src/app/services/user-settings.service';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { UserSettings } from 'src/shared/models/user-settings.model';
import { NoteFolderService } from 'src/app/services/note-folder.service';

@Component({
  selector: 'notes-page',
  templateUrl: './notes-page.component.html',
  styleUrls: ['./notes-page.component.scss']
})

export class NotesPageComponent implements OnInit {
  currentFolder: Folder = new Folder(); // folder path example: "root/folder name/folder name/folder name/folder name/folder name"
  sidebarButtons: MenuButton[] = [];

  path: string = "Loading...";


  userProfile: UserProfile;
  userSettings: UserSettings;
  
  constructor(
    private userProfileService: UserProfileService, 
    private userSettingsService: UserSettingsService,
    private folderService: NoteFolderService
    ) { }
  
  async ngOnInit() {
    this.userProfileService.userProfile.subscribe(profile => this.userProfile = profile);
    this.userSettingsService.userSettings.subscribe(settings => this.userSettings = settings);
  
    this.sidebarButtons.push(new MenuButton(MenuButtonType.RecentActions));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Search));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Notifications));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.AddNote));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.AddFolder));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.TrashCan));
    
    this.currentFolder = await this.folderService.getFolder(this.userSettings.rootFolderId);  

    this.path = this.currentFolder.name == 'Root' ? '' : this.currentFolder.name;

    console.log(' page2 ' + this.currentFolder);
    this.currentFolder.cards.push(
      new NoteCard("Magic happens!", "Hello world qqqqqq wwwWwww eeeeee 3333333 3333 33333 33333 333333"),
      new NoteCard("Very loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong name","good times are comin'")
    );

    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
    this.currentFolder.subfolders.push(new Folder());
  }
}