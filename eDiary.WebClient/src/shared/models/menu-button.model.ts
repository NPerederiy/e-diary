import { MenuButtonType } from "./menu-button-type.enum";

export class MenuButton{
    content: string;
    type: MenuButtonType;
    isActive: boolean;

    constructor(content: string, type: MenuButtonType, isActive?: boolean) {
        this.content = content;
        this.type = type;
        this.isActive = isActive || false;
    }

    setActive(){
        this.isActive = true;
    }

    setNotActive(){
        this.isActive = false;
    }
}