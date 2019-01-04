import { Component, OnInit, Input } from '@angular/core';
import { MenuButton } from 'src/shared/models/menu-button.model';

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

}
