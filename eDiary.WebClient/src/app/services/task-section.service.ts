import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { TaskSection } from "src/shared/models/task-list.model";

@Injectable()
export class TaskSectionService{

    private readonly serverURI = "http://localhost:8181";
    private readonly controllerName = "Sections";

    constructor(
        private http: HttpClient
        ) { }
    
    public getSections(projectId: number){
        return this.http.get(`${this.serverURI}/api/ProjectPage/${projectId}`).toPromise();
    }

    public addSection(name: string, projectId: number){  
        let body: any = {};
        body.name = name;
        body.projectId = projectId;
        return this.http.post(`${this.serverURI}/api/${this.controllerName}`, body).toPromise();
    }

    public updateSection(section: TaskSection){
        // TODO: Implement
        console.log("update section");
    }

    public removeSection(id: number){
        return this.http.delete(`${this.serverURI}/api/${this.controllerName}/${id}`).toPromise();
    }
}