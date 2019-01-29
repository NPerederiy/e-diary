import { Component, OnInit } from '@angular/core';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { CalendarView } from 'src/shared/models/calendar-view.enum';

@Component({
  selector: 'calendar-page',
  templateUrl: './calendar-page.component.html',
  styleUrls: ['./calendar-page.component.scss']
})

export class CalendarPageComponent implements OnInit {
  sidebarButtons: MenuButton[] = [];
  currentViewType: CalendarView;

  constructor() { 
    this.currentViewType = CalendarView.Month;
    this.sidebarButtons.push(new MenuButton(MenuButtonType.RecentActions));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.MonthView));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.WeekView));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.DayView));
  }

  ngOnInit() {
  }

}
