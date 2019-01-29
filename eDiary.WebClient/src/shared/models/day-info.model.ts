export class DayInfo{
    dayInMonth: number;
    allTasks: any[] = [];
    importantTasks: any[] = [];
    hotTasks: any[] = [];
    workload: number = 0;

    constructor(dayInMonth: number) {
        this.dayInMonth = dayInMonth;

        this.workload = this.getRandomArbitrary(0,100);
    }

    private getRandomArbitrary(min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
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

    getDayWorkload(): string{
        if(this.workload >= 0 && this.workload < 25){
            return 'low';
        } else
        if(this.workload >= 25 && this.workload < 50){
            return 'belowMedium';
        } else 
        if(this.workload >= 50 && this.workload < 75){
            return 'aboveMedium';
        } else
        if(this.workload >= 75 && this.workload <= 100){
            return 'high';
        } else {            
            return "incorrect value";
        }
    }

    getWorkloadInPercents(): number{
        return this.workload;
    }
}