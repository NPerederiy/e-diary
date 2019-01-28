import { Component, OnInit, Input } from '@angular/core';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';

@Component({
  selector: 'sidebar-button',
  templateUrl: './sidebar-button.component.html',
  styleUrls: ['./sidebar-button.component.scss']
})

export class SidebarButtonComponent implements OnInit {
  @Input() button: MenuButton;

  constructor() { }

  ngOnInit() {
  }

  isHistory(): boolean{
    return this.button.type === MenuButtonType.RecentActions;
  }

  isSearch(): boolean{
    return this.button.type === MenuButtonType.Search;
  }

  isNotifications(): boolean{
    return this.button.type === MenuButtonType.Notifications;
  }

}
