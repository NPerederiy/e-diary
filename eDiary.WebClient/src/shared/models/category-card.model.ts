import { ProjectCard } from "./project-card.model";

export class CategoryCard{
    name: string;
    projects: ProjectCard[];

    constructor(name: string, projects?: ProjectCard[]) {
        this.name = name;
        this.projects = projects || [];
    }
}