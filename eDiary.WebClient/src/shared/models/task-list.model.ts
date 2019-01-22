import { TaskCard } from "./task-card.model";

export class TaskList{
    name: string;
    cards: TaskCard[];

    constructor(name?: string, cards?: TaskCard[]) {
        this.name = name || "";
        this.cards = cards || [];
    }
}