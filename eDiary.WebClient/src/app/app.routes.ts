import { Routes } from "@angular/router";
import { AuthGuard } from "./services/auth/authGuard";
import { MainComponent } from "./main/main.component";
import { HomePageComponent } from "./main/home-page/home-page.component";
import { TasksPageComponent } from "./main/tasks-page/tasks-page.component";
import { NotesPageComponent } from "./main/notes-page/notes-page.component";
import { CalendarPageComponent } from "./main/calendar-page/calendar-page.component";
import { RegisterComponent } from "./register/register.component";
import { LoginComponent } from "./login/login.component";

export const appRoutes: Routes = [
    { 
        path: '', 
        redirectTo: '/app', 
        pathMatch: 'full',
        canActivate: [AuthGuard]
    },
    { 
        path: 'app', 
        component: MainComponent,
        children: [
            // { path: '', component: HomePageComponent },
            // { path: 'tasks', component: TasksPageComponent },
            { path: '', component: TasksPageComponent },
            { path: 'notes', component: NotesPageComponent },
            { path: 'calendar', component: CalendarPageComponent }
        ]
    },
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegisterComponent },
]