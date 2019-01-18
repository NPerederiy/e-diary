import { TaskStatus } from "./task-status.enum";
import { CardStatus } from "./card-status.enum";

export class TaskCard{
    header: string;
    descr: string;
    taskStatus: TaskStatus;
    cardStatus: CardStatus;

    constructor(header: string, descr?: string, taskStatus?: TaskStatus, cardStatus?: CardStatus){
        this.header = header;
        this.descr = descr || "";
        this.taskStatus = taskStatus || TaskStatus.toDo;
        this.cardStatus = cardStatus || CardStatus.hidden;
    }
}