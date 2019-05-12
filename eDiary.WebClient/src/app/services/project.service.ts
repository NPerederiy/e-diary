import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ProjectCard } from "src/shared/models/project-card.model";

@Injectable()
export class ProjectService{

    private readonly serverURI = "http://localhost:8181";
    private readonly controllerName = "Projects";

    constructor(
        private http: HttpClient
        ) { }
    
    public getAllProjects(){
        return this.http.get(`${this.serverURI}/api/${this.controllerName}`).toPromise();
    }

    public addProject(name: string, categoryId?: number){
        let body: any = {};
        body.name = name;
        body.categoryId = categoryId;
        return this.http.post(`${this.serverURI}/api/${this.controllerName}`, body).toPromise();
    }

    public renameProject(project: ProjectCard){
        // TODO: Implement

        this.updateProject(project);
    }

    public updateProject(project: ProjectCard){
        // TODO: Implement
        console.log("update project");
    }

    public removeProject(id: number){
        return this.http.delete(`${this.serverURI}/api/${this.controllerName}/${id}`).toPromise();
    }
}