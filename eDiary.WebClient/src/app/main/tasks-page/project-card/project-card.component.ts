import { Component, OnInit, Input, Output, ViewChild, ElementRef, EventEmitter } from '@angular/core';
import { ProjectCard } from 'src/shared/models/project-card.model';

@Component({
  selector: 'project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.scss']
})

export class ProjectCardComponent implements OnInit {
  @Input() card: ProjectCard;
  @Output() editorOpened: EventEmitter<any> = new EventEmitter();
  @Output() editorClosed: EventEmitter<any> = new EventEmitter();
  @ViewChild('projectEditor') projectEditor: ElementRef;
  
  public doughnutChartLabels: string[] = ['Hot', 'Important', 'Completed', 'In progress', 'Overdue'];  // TODO: Get this from API
  public doughnutChartData: number[] = [];
  public doughnutChartType: string = 'doughnut';
  public doughnutChartOptions:any = {
    cutoutPercentage: 85,
    legend: {
      display: false,
      position: 'bottom',
      labels: {
          fontColor: 'rgba(55, 51, 49, 0.7)',
          fontFamily: 'HP-Simplified-Light, Latin-Greek-Cyrillic-Light',
          fontSize: 14,
          boxWidth: 14,
          padding: 20
      }
    }    
  };
  
  private readonly colors: string[] = [
    '#ff5576', // 'rgba(231, 76, 60, 1)', // '#e74c3c', // red
    '#f7da59', // 'rgba(241, 196, 15, 1)', // '#f1c40f', // yellow
    '#6dc188', // 'rgba(46, 204, 113, 1)', // '#2ecc71', // green
    '#71c2ff', // 'rgba(52, 152, 219, 1)', // '#3498db', // blue
    '#ad80e7', // 'rgba(155, 89, 182, 1)', // '#9b59b6', // purple
    'rgba(230, 126, 34, 1)', // '#e67e22', // orange
    'rgba(26, 188, 156, 1)', // '#1abc9c', // green2
    'rgba(189, 189, 189, 0.8)', // Grey
    // '#e8254c', // red
    // '#ff7800', // orange
    // '#ffc000', // yellow
    // '#21c765', // green
    // '#0cc3f0', // blue
  ]

  private readonly hoverColors: string[] = [
    'rgba(231, 76, 60, 0.8)', // '#e74c3c', // red
    'rgba(241, 196, 15, 0.8)', // '#f1c40f', // yellow
    'rgba(46, 204, 113, 0.8)', // '#2ecc71', // green
    'rgba(52, 152, 219, 0.8)', // '#3498db', // blue
    'rgba(155, 89, 182, 0.8)', // '#9b59b6', // purple
    'rgba(230, 126, 34, 0.8)', // '#e67e22', // orange
    'rgba(26, 188, 156, 0.8)', // '#1abc9c', // green2
    'rgba(189, 189, 189, 0.8)', // Grey
  ]

  public doughnutChartColors: any[] = [
    {
      backgroundColor: this.colors,
      hoverBackgroundColor: this.hoverColors,
      borderWidth: 1
    }
  ];

  constructor() {}
  
  ngOnInit() {
    if(this.card.isEditing){
      this.focusOnEditor();
    }
    this.initChart();
  }

  public openEditor(){
    this.editorOpened.emit();
    this.card.isEditing = true;
    this.focusOnEditor();
  }

  public closeEditor(){
    this.card.isEditing = false;
    this.editorClosed.emit();
  }

  public blurEditor(){
    setTimeout(() => this.projectEditor.nativeElement.blur());
  }

  public chartClicked(e: any) {
    // console.log(e);
  }

  public chartHovered(e: any) {
    // console.log(e);
  }

  private focusOnEditor(){
    setTimeout(() => this.projectEditor.nativeElement.focus());
  }

  private initChart(){
    this.doughnutChartData.push(this.card.hotTaskCount);
    this.doughnutChartData.push(this.card.importantTaskCount);
    this.doughnutChartData.push(this.card.completedTaskCount);
    this.doughnutChartData.push(this.card.inProgressTaskCount);
    this.doughnutChartData.push(this.card.overdueTaskCount);

    if(this.card.totalTaskCount > 0){
      this.doughnutChartColors = [
        {
          backgroundColor: this.colors,
          hoverBackgroundColor: this.hoverColors,
          borderWidth: 1
        }
      ];
    } else {
      this.doughnutChartColors = [
        {
          backgroundColor: 'rgba(189, 189, 189, 0.8)',
          hoverBackgroundColor: 'rgba(189, 189, 189, 0.8)',
          borderWidth: 1,
        }
      ];
      this.doughnutChartOptions = {
        cutoutPercentage: 85,
        legend: {
          display: false
        },       
        tooltips: {
          enabled: false
        }
      }
      this.doughnutChartData.push(1);
    }
  }
}
