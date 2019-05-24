import { Component, OnInit, Input } from '@angular/core';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';

@Component({
  selector: 'main-menu-button',
  templateUrl: './main-menu-button.component.html',
  styleUrls: ['./main-menu-button.component.scss']
})

export class MainMenuButtonComponent implements OnInit {
  @Input() btn: MenuButton;

  constructor() {
  }

  ngOnInit() {
    
  }

  isHome(): boolean {
    return this.btn.type === MenuButtonType.Home;
  }

  isTasks(): boolean {
    return this.btn.type === MenuButtonType.Tasks;
  }
  
  isNotes(): boolean {
    return this.btn.type === MenuButtonType.Notes;
  }
  
  isCalendar(): boolean {
    return this.btn.type === MenuButtonType.Calendar;
  }

  isLogout(): boolean {
    return this.btn.type === MenuButtonType.Logout;
  }
}
