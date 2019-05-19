import { TaskStatus } from "./task-status.enum";
import { CardStatus } from "./card-status.enum";

export class TaskCard{
    taskId: number;

    header: string;
    descr: string;

    taskStatus: TaskStatus;
    cardStatus: CardStatus;

    createdAt: string;
    updatedAt: string;

    deadline: string;
    difficulty: string;
    priority: string;
    progress: number;

    comments: any[]
    files: any[]
    links: any[]
    subtasks: any[]
    tags: any[]

    isEditing: boolean;

    constructor(
        header: string, 
        taskId?: number, 
        descr?: string, 
        taskStatus?: TaskStatus, 
        cardStatus?: CardStatus,
        createdAt?: string,
        updatedAt?: string,
        deadline?: string,
        difficulty?: string,
        priority?: string,
        progress?: number,
        comments?: any[],
        files?: any[],
        links?: any[],
        subtasks?: any[],
        tags?: any[]
        ){
        this.taskId = taskId || 0;
        
        this.header = header;
        this.descr = descr || "";

        this.taskStatus = taskStatus || TaskStatus.toDo;
        this.cardStatus = cardStatus || CardStatus.hidden;

        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.deadline = deadline;

        this.difficulty = difficulty || "Low";
        this.priority = priority || "Would have";
        this.progress = progress || 0;

        this.comments = comments || [];
        this.files = files || [];
        this.links = links || [];
        this.subtasks = subtasks || [];
        this.tags = tags || [];

        this.isEditing = false;
    }
}