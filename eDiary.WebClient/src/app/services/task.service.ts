import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TaskCard } from "src/shared/models/task-card.model";
import { CardStatus } from "src/shared/models/card-status.enum";
import { TaskStatus } from "src/shared/models/task-status.enum";

@Injectable()
export class TaskService{

    private readonly serverURI = "http://localhost:8181";
    private readonly controllerName = "Tasks";

    constructor(
        private http: HttpClient
        ) { }

    public getTasks(){
        return this.http.get(`${this.serverURI}/api/${this.controllerName}`).toPromise();
    }

    public addTask(header: string, sectionId: number){
        console.log("add task");
        
        let body: any = {};
        body.header = header;
        body.sectionId = sectionId;
        return this.http.post(`${this.serverURI}/api/${this.controllerName}`, body).toPromise();
    }

    public updateTask(task: TaskCard){ // todo add section id change tracking
        let body: any = {};
        body.taskId = task.taskId;
        body.header = task.header;
        body.descr = task.descr;
        body.taskStatus = this.getTaskStatusValue(task.taskStatus);
        body.cardStatus = this.getCardStatusValue(task.cardStatus);
        
        body.createdAt = task.createdAt;
        body.updatedAt = task.updatedAt;
        body.deadline = task.deadline;
        
        body.difficulty = task.difficulty;
        body.priority = task.priority;
        body.progress = task.progress;
        
        body.comments = task.comments;
        body.files = task.files;
        body.links = task.links;
        body.subtasks = task.subtasks;
        body.tags = task.tags;

        console.log(body);

        return this.http.put(`${this.serverURI}/api/${this.controllerName}`, body).toPromise();

        
    }

    public archiveTask(id: number){
        console.log('removing the task ...');
        // TODO: Implement
        this.removeTask(id);
    }

    public removeTask(id: number){
        return this.http.delete(`${this.serverURI}/api/${this.controllerName}/${id}`).toPromise();
    }

    private getTaskStatusValue(status: TaskStatus): string{
        switch (status){
            case TaskStatus.done:
                return "Done";
            case TaskStatus.toDo:
                return "To do";
            case TaskStatus.inProcess:
                return "In progress"
            case TaskStatus.closed:
                return "Canceled";
        }
    }

    private getCardStatusValue(status: CardStatus): string{
        switch (status){
            case CardStatus.completed:
                return "Completed";
            case CardStatus.deleted:
                return "Deleted";
            case CardStatus.hidden:
                return "Hidden";
            case CardStatus.hot:
                return "Hot";
            case CardStatus.important:
                return "Important";
        }
    }
}