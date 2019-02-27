import { Component, OnInit, Input } from '@angular/core';
import { ProjectCard } from 'src/shared/models/project-card.model';

@Component({
  selector: 'project-card',
  templateUrl: './project-card.component.html',
  styleUrls: ['./project-card.component.scss']
})

export class ProjectCardComponent implements OnInit {
  @Input() card: ProjectCard;
  
  public doughnutChartLabels: string[] = ['Hot', 'Important', 'Completed', 'In progress', 'Overdue'];  
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
  
  private colors: string[] = [
    'rgba(231, 76, 60, 1)', // '#e74c3c', // red
    'rgba(241, 196, 15, 1)', // '#f1c40f', // yellow
    'rgba(46, 204, 113, 1)', // '#2ecc71', // green
    'rgba(52, 152, 219, 1)', // '#3498db', // blue
    'rgba(155, 89, 182, 1)', // '#9b59b6', // purple
    'rgba(230, 126, 34, 1)', // '#e67e22', // orange
    'rgba(26, 188, 156, 1)', // '#1abc9c', // green2
    'rgba(189, 189, 189, 0.8)', // Grey
    // '#e8254c', // red
    // '#ff7800', // orange
    // '#ffc000', // yellow
    // '#21c765', // green
    // '#0cc3f0', // blue
  ]

  private hoverColors: string[] = [
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

  public chartClicked(e:any):void {
    console.log(e);
  }

  public chartHovered(e:any):void {
    console.log(e);
  }

}
