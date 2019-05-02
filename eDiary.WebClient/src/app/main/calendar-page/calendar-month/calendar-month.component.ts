import { Component, OnInit } from '@angular/core';
import { DayInfo } from 'src/shared/models/day-info.model';

@Component({
  selector: 'calendar-month',
  templateUrl: './calendar-month.component.html',
  styleUrls: ['./calendar-month.component.scss']
})

export class CalendarMonthComponent implements OnInit {
  selectedYear: number;
  selectedMonth: number;
  selectedDay: number;

  monthes: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  daysOfWeek: string[] = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
  gap: any[] = [];
  days: DayInfo[] = [];

  constructor() {
    let date = new Date();

    this.selectedYear = date.getFullYear();
    this.selectedMonth = date.getMonth();
    this.selectedDay = date.getDate();  
  
    for (let i = 1; i <= new Date(this.selectedYear, this.selectedMonth, 1).getDay(); i++) {
      this.gap.push({});    
    }
    for (let i = 1; i < new Date(this.selectedYear, this.selectedMonth, 0).getDate(); i++) {
      this.days.push(new DayInfo(i));    
    }
  }

  ngOnInit() {
  }

  selectMonth(m: number){
    this.selectedMonth = m;
    this.selectedDay = null;
    console.log(m);    
  }
}
