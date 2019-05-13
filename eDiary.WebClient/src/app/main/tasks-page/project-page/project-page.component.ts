import { Component, OnInit, Input } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskStatus } from 'src/shared/models/task-status.enum';
import { CardStatus } from 'src/shared/models/card-status.enum';
import { TaskSection } from 'src/shared/models/task-list.model';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { ProjectCard } from 'src/shared/models/project-card.model';
import { TaskSectionService } from 'src/app/services/task-section.service';
import { TaskListComponent } from './task-list/task-list.component';

@Component({
  selector: 'project-page',
  templateUrl: './project-page.component.html',
  styleUrls: ['./project-page.component.scss']
})

export class ProjectPageComponent implements OnInit {
  @Input() project: ProjectCard;
  
  sections: TaskSection[] = []; 
  sidebarButtons: MenuButton[] = [];

  private isNewSectionCreating = false;
  private oldSectionName: string;

  scrollbarOptions = { 
    axis: 'x', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor(
    private sectionService: TaskSectionService
    ) {
    this.sidebarButtons.push(new MenuButton(MenuButtonType.RecentActions));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Search));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Notifications));
    // this.sidebarButtons.push(new MenuButton(MenuButtonType.AddTask));
    // this.sidebarButtons.push(new MenuButton(MenuButtonType.TrashCan));
  }

  ngOnInit() {
    this.sectionService.getSections(this.project.projectId)
      .then((sections: TaskSection[]) => {
        this.sections = sections;        
      }, (error: any) => {
        console.error(error);
      });
  }

  /* ---------- Section ---------- */

  addSection(){    
    let s = new TaskSection("");
    s.isEditing = true;
    this.sections.push(s);
    this.isNewSectionCreating = true;    
  }

  editSection(component: TaskListComponent){
    this.oldSectionName = component.section.name;
    component.openSectionEditor();
  }

  removeSection(section: TaskSection){
    this.sectionService.removeSection(section.sectionId);
  }

  saveSectionChanges(section: TaskSection){
    if(this.isNewSectionCreating){
      if(section.name){
        this.sectionService.addSection(section.name, this.project.projectId)
          .then((id: number) => {
            console.log('section id: ',id);
            
            section.sectionId = id;
          });

      } else {
        this.sections.pop();
      }
      this.isNewSectionCreating = false; 
    } else {
      if(section.name){
        this.sectionService.updateSection(section);
      } else {
        console.log("3");
        section.name = this.oldSectionName;
        this.oldSectionName = null;
      }
    }
  }
}
