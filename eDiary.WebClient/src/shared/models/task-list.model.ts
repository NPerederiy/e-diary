import { TaskCard } from "./task-card.model";

export class TaskSection{
    sectionId: number;
    name: string;
    cards: TaskCard[];
    projectId: number;
    isEditing: boolean;

    constructor(name: string, sectionId?: number, projectId?: number, cards?: TaskCard[]) {
        this.name = name || "";
        this.cards = cards || [];
        this.projectId = projectId || 0;
        this.sectionId = sectionId || 0;
        this.isEditing = false;
    }
}