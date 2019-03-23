import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { AccountService } from '../services/account.service';
import { UserProfile } from 'src/shared/models/user-profile.model';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {
  menuButtons: MenuButton[] = [];
  userProfile: UserProfile;

  constructor(private accountService: AccountService, private router: Router, private route: ActivatedRoute) {
   accountService.printTokens();
    // if (this.userProfile === null){
    //   console.log('navigate from main to login');
      
    //   this.router.navigateByUrl('/login');
    // }
    // this.router.navigate(['tasks'], { relativeTo: this.route });
    // this.router.navigate([{ outlets: { 'inner-pages': ['tasks'] } }], { relativeTo: this.route } );

    this.menuButtons.push(
      new MenuButton(MenuButtonType.Home, "", true),
      new MenuButton(MenuButtonType.Tasks, "Tasks"),
      new MenuButton(MenuButtonType.Notes, "Notes"),
      new MenuButton(MenuButtonType.Calendar, "Calendar"),
    )
  }

  ngOnInit() {
    this.accountService.userProfile.subscribe(profile => this.userProfile = profile);
  }

  async openPage(btn: MenuButton){
    this.menuButtons.forEach(b => {
      if(b.content !== btn.content){
        b.setNotActive();
      }
    });
    btn.setActive();
    switch(btn.type){
      case MenuButtonType.Home:
        this.router.navigateByUrl("app");
        // this.router.navigate([{ outlets: { 'inner-pages': [''] } }], { relativeTo: this.route } );
        break;
      case MenuButtonType.Tasks:
      this.router.navigateByUrl("app");
        this.router.navigate([{ outlets: { 'inner-pages': ['tasks'] } }], { relativeTo: this.route } );
        break;
      case MenuButtonType.Notes:
      this.router.navigateByUrl("app");
        this.router.navigate([{ outlets: { 'inner-pages': ['notes'] } }], { relativeTo: this.route } );
        break;
      case MenuButtonType.Calendar:
      console.log(await this.accountService.getProfile(3));;
      this.router.navigateByUrl("app");
        this.router.navigate([{ outlets: { 'inner-pages': ['calendar'] } }], { relativeTo: this.route } );
        break;
    }
    // TODO: implement routing to the specified page
  }

}
