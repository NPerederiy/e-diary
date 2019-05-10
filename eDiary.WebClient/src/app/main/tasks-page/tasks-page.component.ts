import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { CategoryCard } from 'src/shared/models/category-card.model';
import { ProjectCard } from 'src/shared/models/project-card.model';
import { ProjectCategoryService } from 'src/app/services/project-category.service';
import { CategoryCardComponent } from './category-card/category-card.component';

@Component({
  selector: 'tasks-page',
  templateUrl: './tasks-page.component.html',
  styleUrls: ['./tasks-page.component.scss']
})

export class TasksPageComponent implements OnInit {
  categories: CategoryCard[] = []; 
  projects: ProjectCard[] = [];

  currentCategory: CategoryCard = null;
  currentProject: ProjectCard = null;

  isNewCategoryCreating = false;

  scrollbarOptions = { 
    axis: 'x', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor(
    private prjCategoryService: ProjectCategoryService
  ) {
    // this.categories.push(new CategoryCard("University"));
    // this.categories.push(new CategoryCard("Work"));
    // this.categories.push(new CategoryCard("Family"));
    // this.categories.push(new CategoryCard("TRVL"));

    this.projects.push(new ProjectCard("Project name1"));
    this.projects.push(new ProjectCard("Flight to the Moon", 0, 2, 10, 15, 7, 3, ));
    this.projects.push(new ProjectCard("Hyperloop launch", 0, 95, 131, 452, 33, 31));
    this.projects.push(new ProjectCard("Trip around the world", 0, 30, 55, 201, 115, 9));
    this.projects.push(new ProjectCard("Complete the diary", 0, 30, 15, 281, 105, 9));
  }

  /*async*/ ngOnInit() {
    /*await*/ this.prjCategoryService.getAllCategories().then((categories: {name: string, projects:{
      projectName: string,
      projectId: number,
      hotTaskCount: number,
      importantTaskCount: number,
      completedTaskCount: number,
      inProgressTaskCount: number,
      overdueTaskCount: number,
      totalTaskCount: number }[] }[] ) => {
        categories.forEach(c => {
          let projects: ProjectCard[] = [];
          c.projects.forEach(p => {
            projects.push(new ProjectCard(
              p.projectName, 
              p.projectId, 
              p.hotTaskCount, 
              p.importantTaskCount, 
              p.completedTaskCount, 
              p.inProgressTaskCount, 
              p.overdueTaskCount));
          });
          this.categories.push(new CategoryCard(c.name, 0, projects));
        });
      },
      (error: any) => console.error(error)
    );
    // console.log('Current project: ',this.currentProject);
    // console.log('Categories: ', this.categories);
  }

  isProjectSelected(): boolean{
    return this.currentProject !== null;
  }

  openProjectPage(card: ProjectCard){
    this.currentProject = card;
  }

  openCategoryProjects(card: CategoryCard){
    console.log('Click: ', card);
  }

  editCategory(card: CategoryCardComponent){
    console.log(card);
    card.openEditor();
  }

  addCategory(){
    this.categories.push(new CategoryCard("", 0, [], true));
    this.isNewCategoryCreating = true;
  }

  saveCategoryChanges(card: CategoryCard){
    if(this.isNewCategoryCreating){
      if(card.name){
        console.log(card.name);
        
        this.prjCategoryService.addCategory(card.name);
      } else {
        this.categories.pop();
      }
      this.isNewCategoryCreating = false;
    } else {
      if(card.name){
        this.prjCategoryService.updateCategory(card); 
      }
    }


    if (this.isNewCategoryCreating && card.name) {
       
    } else if (this.isNewCategoryCreating && card.name) {
      this.prjCategoryService.updateCategory(card); 
    }
  }

  addProject(){
    console.log('addProject');
    
  }
}
