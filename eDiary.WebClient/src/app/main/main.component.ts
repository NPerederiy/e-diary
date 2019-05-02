import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { UserProfile } from 'src/shared/models/user-profile.model';
import { UserSettings } from 'src/shared/models/user-settings.model';
import { UserProfileService } from '../services/user-profile.service';
import { UserSettingsService } from '../services/user-settings.service';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {
  menuButtons: MenuButton[] = [];
  userProfile: UserProfile;
  userSettings: UserSettings;

  constructor(
      private userProfileService: UserProfileService, 
      private userSettingsService: UserSettingsService, 
      private router: Router, 
      private route: ActivatedRoute,
      private accountService: AccountService
    ) {
    this.menuButtons.push(
      new MenuButton(MenuButtonType.Home, "", true),
      new MenuButton(MenuButtonType.Tasks, "Tasks"),
      new MenuButton(MenuButtonType.Notes, "Notes"),
      new MenuButton(MenuButtonType.Calendar, "Calendar"),
    )
  }

  ngOnInit() {
    this.userProfileService.userProfile.subscribe(profile => this.userProfile = profile);
    this.userSettingsService.userSettings.subscribe(settings => this.userSettings = settings);

    if(!this.userProfile.profileId){
    if(sessionStorage["uprofile"]){
      this.userProfileService.updateUserProfile(JSON.parse(sessionStorage.getItem("uprofile")));
    } else {
      this.accountService.logout();
    }}
    
    if(!this.userSettings.userId){ 
      if (sessionStorage["uprofile"]){
        this.userSettingsService.updateUserSettings(JSON.parse(sessionStorage.getItem("usettings")));
      } else {
        this.accountService.logout();
      }
    }
  }

  public openPage(btn: MenuButton){
    this.menuButtons.forEach(b => {
      if(b.content !== btn.content){
        b.setNotActive();
      }
    });
    btn.setActive();
    switch(btn.type){
      case MenuButtonType.Home:
        this.router.navigate(["app"]);
        break;
      case MenuButtonType.Tasks:
      this.router.navigate(["tasks"], {relativeTo: this.route});
        break;
      case MenuButtonType.Notes:
      this.router.navigate(["notes"], {relativeTo: this.route});
        break;
      case MenuButtonType.Calendar:
      this.router.navigate(["calendar"], {relativeTo: this.route});
        break;
    }
  }
}
