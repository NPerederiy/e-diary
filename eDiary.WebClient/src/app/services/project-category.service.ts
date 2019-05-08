import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CategoryCard } from "src/shared/models/category-card.model";

@Injectable()
export class ProjectCategoryService{

    private readonly serverURI = "http://localhost:8181";

    constructor(
        private http: HttpClient
        ) { }

    public getAllCategories() {
        return this.http.get(`${this.serverURI}/api/PrjCategories`).toPromise();
    }

    public addCategory(categoryName: string){
        let body: any = {};
        body.name = categoryName;
        return this.http.post(`${this.serverURI}/api/PrjCategories`, body).toPromise()
    }

    public editCategory(category: CategoryCard){
        // TODO: Implement
    }

    public deleteCategory(id: number){
        return this.http.delete(`${this.serverURI}/api/PrjCategories/${id}`).toPromise();
    }
}
