import { Component, OnInit, Input } from '@angular/core';
import { MenuButton } from 'src/shared/models/menu-button.model';

@Component({
  selector: 'sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent implements OnInit {
  @Input() buttons: MenuButton[] = [];

  constructor() {
  }

  ngOnInit() {
  }

}
