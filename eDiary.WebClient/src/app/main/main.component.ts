import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})

export class MainComponent implements OnInit {
  menuButtons: MenuButton[] = [];

  constructor(private authService: AuthenticationService, private router: Router) {
    if (!authService.checkAuthToken("")){
      //this.router.navigateByUrl('/login');
    }
    this.menuButtons.push(
      new MenuButton("", MenuButtonType.Home, true),
      new MenuButton("Tasks", MenuButtonType.Tasks),
      new MenuButton("Notes", MenuButtonType.Notes),
      new MenuButton("Calendar", MenuButtonType.Calendar),
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
    // TODO: implement routing to the specified page
  }

}
