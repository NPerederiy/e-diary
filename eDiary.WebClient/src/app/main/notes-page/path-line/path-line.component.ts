import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'path-line',
  templateUrl: './path-line.component.html',
  styleUrls: ['./path-line.component.scss']
})
export class PathLineComponent implements OnInit {
  @Input() fullpath: string;
  folders: string[] = [];

  constructor() { }

  ngOnInit() {
    this.folders = this.parse(this.fullpath);
  }

  private parse(path: string): string[]{
    return path.split('/');
  }

  isRoot(i: number): boolean{
    console.log(i);
    
    return i === 0;
  }

}
