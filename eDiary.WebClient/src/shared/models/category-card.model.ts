import { ProjectCard } from "./project-card.model";

export class CategoryCard{
    id: number;
    name: string;
    isEditing: boolean;
    projects: ProjectCard[];

    constructor(name: string, id?:number, projects?: ProjectCard[]) {
        this.id = id || 0;
        this.name = name;
        this.projects = projects || [];
        this.isEditing = false;
    }
}