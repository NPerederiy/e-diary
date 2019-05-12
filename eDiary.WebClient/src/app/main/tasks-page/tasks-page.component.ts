import { Component, OnInit } from '@angular/core';
import { CategoryCard } from 'src/shared/models/category-card.model';
import { ProjectCard } from 'src/shared/models/project-card.model';
import { ProjectCategoryService } from 'src/app/services/project-category.service';
import { CategoryCardComponent } from './category-card/category-card.component';
import { ProjectCardComponent } from './project-card/project-card.component';
import { ProjectService } from 'src/app/services/project.service';

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

  private isNewCategoryCreating = false;
  private isNewProjectCreating = false;

  scrollbarOptions = { 
    axis: 'x', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor(
    private projectCategoryService: ProjectCategoryService,
    private projectService: ProjectService
  ) { }

  ngOnInit() {
    this.loadCategories();
    this.loadProjects();
  }

  /* ---------- Category ---------- */
  
  public addCategory(){
    let c = new CategoryCard("");
    c.isEditing = true;
    this.categories.push(c);
    this.isNewCategoryCreating = true;
  }

  public editCategory(category: CategoryCardComponent){
    category.openEditor();
  }

  public removeCategory(card: CategoryCard){  // TODO: verify
    this.projectCategoryService.deleteCategory(card.id);
    this.categories.splice(this.categories.indexOf(card), 1);
    console.log('Categories list after removing the item: ', this.categories); // TODO: remove this line later
  }

  public saveCategoryChanges(card: CategoryCard){
    if(this.isNewCategoryCreating){
      if(card.name){
        this.projectCategoryService.addCategory(card.name);
      } else {
        this.categories.pop();
      }
      this.isNewCategoryCreating = false;
    } else {
      if(card.name){
        this.projectCategoryService.renameCategory(card); 
      }
    }
  }

  public loadCategories(){
    this.projectCategoryService.getAllCategories()
      .then((categories: CategoryCard[] ) => {
        this.categories = categories;
      },
      (error: any) => {
        return console.error(error);
      });
  }

  public selectCategory(card: CategoryCard){
    console.log('selected category: ', card); // TODO: remove this line later
    this.currentCategory = card;
    this.projects = card.projects;
  }

  /* ---------- Project ---------- */

  public addProject(){
    let p = new ProjectCard("");
    p.isEditing = true;
    this.projects.push(p);
    this.isNewProjectCreating = true;
  }

  public editProject(project: ProjectCardComponent){
    project.openEditor();
  }

  public removeProject(card: ProjectCard){
    this.projectService.removeProject(card.projectId);
  }

  public saveProjectChanges(card: ProjectCard){
    if(this.isNewProjectCreating){
      if(card.projectName){
        if(this.currentCategory){
          this.projectService.addProject(card.projectName, this.currentCategory.id)
        } else {
          this.projectService.addProject(card.projectName);
        }
      } else {
        this.projects.pop();
      }
      this.isNewProjectCreating = false;
    } else {
      if(card.projectName){
        this.projectService.renameProject(card); 
      }
    }
  }
  
  public loadProjects(){
    if(this.currentCategory){
      this.projects = this.currentCategory.projects;
    } else {
      this.projectService.getAllProjects()
      .then((projects: ProjectCard[]) => {        
        this.projects = projects;
      }, (error: any) => {
        return console.error(error);
      });
    }
  }

  public selectProject(card: ProjectCard){
    this.currentProject = card;
  }

  public showAllProjects(){
    this.currentCategory = null;
    this.loadProjects();
  }
}
