import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {
  menuButtons: MenuButton[] = [];

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) {
    if (!authService.checkAuthToken("")){
      //this.router.navigateByUrl('/login');
    }
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
  }

  openPage(btn: MenuButton){
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
      this.router.navigateByUrl("app");
        this.router.navigate([{ outlets: { 'inner-pages': ['calendar'] } }], { relativeTo: this.route } );
        break;
    }
    // TODO: implement routing to the specified page
  }

}
