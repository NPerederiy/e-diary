import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { CategoryCard } from "src/shared/models/category-card.model";
import { ProjectCard } from "src/shared/models/project-card.model";

@Injectable()
export class ProjectCategoryService{

    private readonly serverURI = "http://localhost:8181";
    private readonly controllerName = "ProjectCategories";

    constructor(
        private http: HttpClient
        ) { }

    public getAllCategories() {
        return this.http.get(`${this.serverURI}/api/${this.controllerName}`).toPromise();
    }

    public addCategory(categoryName: string){
        let contentType = new HttpHeaders({'content-type': 'application/json'});
        return this.http.post(`${this.serverURI}/api/${this.controllerName}`, JSON.stringify(categoryName), {headers: contentType}).toPromise();
    }

    public updateCategoryName(category: CategoryCard){
        // TODO: implement 
    }

    // public updateCategoryProjects(category: CategoryCard){

    // }

    public updateCategory(category: CategoryCard){  // TODO: Verify 
        console.log("update category");

        let body: any = {};
        body.categoryId = category.id;
        body.name = category.name;
        body.projects = category.projects;
        return this.http.put(`${this.serverURI}/api/${this.controllerName}`, body).toPromise()
        
    }

    public deleteCategory(id: number){
        return this.http.delete(`${this.serverURI}/api/${this.controllerName}/${id}`).toPromise();
    }
}
