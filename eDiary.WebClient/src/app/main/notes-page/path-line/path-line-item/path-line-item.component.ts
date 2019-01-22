import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'path-line-item',
  templateUrl: './path-line-item.component.html',
  styleUrls: ['./path-line-item.component.scss']
})
export class PathLineItemComponent implements OnInit {
  @Input() folder: string;
  @Input() isRoot: boolean;
  
  constructor() { }

  ngOnInit() {
  }

}
