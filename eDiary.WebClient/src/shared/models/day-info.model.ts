export class DayInfo{
    dayInMonth: number;
    allTasks: any[] = [];
    importantTasks: any[] = [];
    hotTasks: any[] = [];

    constructor(dayInMonth: number) {
        this.dayInMonth = dayInMonth;
    }

    getTasksCount(): number{
        return this.allTasks.length;
    }

    getHotTasksCount(): number{
        return this.hotTasks.length;
    }

    getImportantTasksCount(): number{
        return this.importantTasks.length;
    }
}