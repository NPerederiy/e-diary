import { Component, OnInit } from '@angular/core';
import { CategoryCard } from 'src/shared/models/category-card.model';
import { ProjectCard } from 'src/shared/models/project-card.model';

@Component({
  selector: 'tasks-page',
  templateUrl: './tasks-page.component.html',
  styleUrls: ['./tasks-page.component.scss']
})

export class TasksPageComponent implements OnInit {
  categories: CategoryCard[] = []; 
  projects: ProjectCard[] = [];
  scrollbarOptions = { 
    axis: 'x', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor() {
    this.categories.push(new CategoryCard("University"));
    this.categories.push(new CategoryCard("Work"));
    this.categories.push(new CategoryCard("Family"));
    this.categories.push(new CategoryCard("TRVL"));

    this.projects.push(new ProjectCard("Project name1"));
    this.projects.push(new ProjectCard("Flight to the Moon", 0, 2, 10, 15, 7, 3, ));
    this.projects.push(new ProjectCard("Hyperloop launch", 0, 95, 131, 452, 33, 31));
    this.projects.push(new ProjectCard("Trip around the world", 0, 30, 55, 201, 115, 9));
    this.projects.push(new ProjectCard("Complete the diary", 0, 30, 15, 281, 105, 9));
  }

  ngOnInit() {
  }

  openProjectPage(card: CategoryCard){
    console.log('Click: ', card);
    
  }

  openCategoryProjects(card: ProjectCard){
    console.log('Click: ', card);
    
  }

  addCategory(){
    console.log('addCategory');
    
  }

  addProject(){
    console.log('addProject');
    
  }

}
