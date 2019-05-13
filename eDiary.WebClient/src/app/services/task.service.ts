import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TaskCard } from "src/shared/models/task-card.model";

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

    public updateTask(task: TaskCard){
        // TODO: Implement
        console.log("update task");
    }

    public removeTask(id: number){
        return this.http.delete(`${this.serverURI}/api/${this.controllerName}/${id}`).toPromise();
    }
}