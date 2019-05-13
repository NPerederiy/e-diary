import { TaskStatus } from "./task-status.enum";
import { CardStatus } from "./card-status.enum";

export class TaskCard{
    id: number;
    header: string;
    descr: string;
    taskStatus: TaskStatus;
    cardStatus: CardStatus;
    isEditing: boolean;

    constructor(header: string, id?: number, descr?: string, taskStatus?: TaskStatus, cardStatus?: CardStatus){
        this.header = header;
        this.id = id || 0;
        this.descr = descr || "";
        this.taskStatus = taskStatus || TaskStatus.toDo;
        this.cardStatus = cardStatus || CardStatus.hidden;
        this.isEditing = false;
    }
}