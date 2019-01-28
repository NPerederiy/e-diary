import { Component, OnInit } from '@angular/core';
import { DayInfo } from 'src/shared/models/day-info.model';

@Component({
  selector: 'calendar-month',
  templateUrl: './calendar-month.component.html',
  styleUrls: ['./calendar-month.component.scss']
})

export class CalendarMonthComponent implements OnInit {

  monthes: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  daysOfWeek: string[] = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
  gap: any[] = [];
  days: DayInfo[] = [];

  constructor() {
    for (let i = 1; i <= 6; i++) {
      this.gap.push({});    
    }
    for (let i = 1; i <= 31; i++) {
      this.days.push(new DayInfo(i));    
    }
  }

  ngOnInit() {
  }

}
