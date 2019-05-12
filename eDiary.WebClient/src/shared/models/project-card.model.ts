export class ProjectCard{
    projectName: string;
    projectId: number;
    hotTaskCount: number;
    importantTaskCount: number;
    completedTaskCount: number;
    inProgressTaskCount: number;
    overdueTaskCount: number;
    totalTaskCount: number;
    isEditing: boolean;

    constructor(name: string, id?: number, hotTaskCount?: number, importantTaskCount?: number, completedTaskCount?: number, 
        inProgressTaskCount?: number, overdueTaskCount?: number) {
        this.projectName = name;
        this.projectId = id;
        this.hotTaskCount = hotTaskCount || 0;
        this.importantTaskCount = importantTaskCount || 0;
        this.completedTaskCount = completedTaskCount || 0;
        this.inProgressTaskCount = inProgressTaskCount || 0;
        this.overdueTaskCount = overdueTaskCount || 0;
        this.totalTaskCount = this.hotTaskCount +
                            this.importantTaskCount +
                            this.completedTaskCount +
                            this.inProgressTaskCount +
                            this.overdueTaskCount;
        this.isEditing = false;
    }
}