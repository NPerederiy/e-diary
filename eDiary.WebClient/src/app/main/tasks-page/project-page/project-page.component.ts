import { Component, OnInit, Input } from '@angular/core';
import { TaskCard } from 'src/shared/models/task-card.model';
import { TaskStatus } from 'src/shared/models/task-status.enum';
import { CardStatus } from 'src/shared/models/card-status.enum';
import { TaskList } from 'src/shared/models/task-list.model';
import { MenuButton } from 'src/shared/models/menu-button.model';
import { MenuButtonType } from 'src/shared/models/menu-button-type.enum';
import { ProjectCard } from 'src/shared/models/project-card.model';

@Component({
  selector: 'project-page',
  templateUrl: './project-page.component.html',
  styleUrls: ['./project-page.component.scss']
})

export class ProjectPageComponent implements OnInit {
  @Input() project: ProjectCard;
  
  cardLists: TaskList[] = []; 
  sidebarButtons: MenuButton[] = [];

  scrollbarOptions = { 
    axis: 'x', 
    theme: 'minimal-dark', 
    scrollbarPosition: 'outside',
    scrollInertia: '200',
  };

  constructor() {
    this.sidebarButtons.push(new MenuButton(MenuButtonType.RecentActions));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Search));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.Notifications));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.AddTask));
    this.sidebarButtons.push(new MenuButton(MenuButtonType.TrashCan));
    
    this.cardLists.push(new TaskList("New list",[
      new TaskCard("Lorem ipsum", "", TaskStatus.inProcess, CardStatus.deleted),
      new TaskCard("Dolor sit amet", "", TaskStatus.toDo, CardStatus.important),
      new TaskCard("Some task header", "some dummy description", TaskStatus.done, CardStatus.completed),
      new TaskCard("new task(1)", "", TaskStatus.inProcess, CardStatus.hot),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)")
    ]));
    this.cardLists.push(new TaskList("New list"));
    this.cardLists.push(new TaskList("New list"));
    this.cardLists.push(new TaskList("New list",[
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)")
    ]));
    this.cardLists.push(new TaskList("New list",[
      new TaskCard("Dolor sit amet", "", TaskStatus.toDo, CardStatus.important),
      new TaskCard("new task(1)", "", TaskStatus.inProcess, CardStatus.hot),
      new TaskCard("new task(1)", "", TaskStatus.inProcess, CardStatus.hot),
    ]));
    this.cardLists.push(new TaskList("New list",[
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)")
    ]));
    this.cardLists.push(new TaskList("New list",[
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)"),
      new TaskCard("new task(2)")
    ]));
  }

  ngOnInit() {
  }

  addColumn(){
    this.cardLists.push(new TaskList());
  }
}
