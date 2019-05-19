import { Injectable } from "@angular/core";

@Injectable()
export class NotificationService{

    constructor() { }

    public showNotification(message: string, backgroundElements?: string[]){
        // TODO: Implement

        if(backgroundElements){
            this.blurBackgroundElements(backgroundElements);
        }
    }

    public hideNotification(){
        // TODO: Implement
    }

    public blurBackgroundElements(elementIds: string[]){
        elementIds.forEach(id => {
            this.blurElement(id);
        });
    }

    public unblurBackgroundElements(elementIds: string[]){
        elementIds.forEach(id => {
            this.unblurElement(id);
        });
    }

    private blurElement(elementId: string){
      let el = document.getElementById(elementId);
      el.classList.add('blurred');
    }
  
    private unblurElement(elementId: string){
      let el = document.getElementById(elementId);
      el.classList.remove('blurred');
    }
}