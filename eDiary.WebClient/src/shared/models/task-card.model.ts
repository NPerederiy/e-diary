export class TaskCard{
    taskId: number;

    header: string;
    descr: string;

    taskStatus: string;
    cardStatus: string;

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
        taskStatus?: string, 
        cardStatus?: string,
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

        this.taskStatus = taskStatus || "To do";
        this.cardStatus = cardStatus || "Hidden";

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