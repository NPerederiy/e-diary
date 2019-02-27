import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'chart-legend-item',
  templateUrl: './chart-legend-item.component.html',
  styleUrls: ['./chart-legend-item.component.scss']
})

export class ChartLegendItemComponent implements OnInit {
  @Input() value: string;
  @Input() color: string;
  @Input() count: number;

  constructor() { }

  ngOnInit() { }

}
