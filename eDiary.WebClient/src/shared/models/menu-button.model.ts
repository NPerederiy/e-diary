import { MenuButtonType } from "./menu-button-type.enum";

export class MenuButton{
    content: string;
    type: MenuButtonType;
    isActive: boolean;

    constructor(type: MenuButtonType, content?: string, isActive?: boolean) {
        this.content = content || "";
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