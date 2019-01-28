import { Component, OnInit, Input } from '@angular/core';
import { DayInfo } from 'src/shared/models/day-info.model';

@Component({
  selector: 'day-card',
  templateUrl: './day-card.component.html',
  styleUrls: ['./day-card.component.scss']
})

export class DayCardComponent implements OnInit {
  @Input() dayInfo: DayInfo;

  constructor() { }

  ngOnInit() {
  }

}
