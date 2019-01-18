import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { RegisterComponent } from './register/register.component';
import { MainComponent } from './main/main.component';
import { AuthenticationService } from './services/authentication.service';
import { MainMenuButtonComponent } from './main-menu-button/main-menu-button.component';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './main/home-page/home-page.component';
import { CalendarPageComponent } from './main/calendar-page/calendar-page.component';
import { NotesPageComponent } from './main/notes-page/notes-page.component';
import { TasksPageComponent } from './main/tasks-page/tasks-page.component';
import { TaskListComponent } from './main/tasks-page/task-list/task-list.component';
import { TaskCardComponent } from './main/tasks-page/task-list/task-card/task-card.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserProfileComponent,
    RegisterComponent,
    MainComponent,
    MainMenuButtonComponent,
    HomePageComponent,
    CalendarPageComponent,
    NotesPageComponent,
    TasksPageComponent,
    TaskListComponent,
    TaskCardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/app', pathMatch: 'full' },
      { 
        path: 'app', 
        component: MainComponent,
        children: [
          { path: '', component: HomePageComponent, outlet:"inner-pages" },
          { path: 'tasks', component: TasksPageComponent, outlet:"inner-pages" },
          { path: 'notes', component: NotesPageComponent, outlet:"inner-pages" },
          { path: 'calendar', component: CalendarPageComponent, outlet:"inner-pages" }
        ]
      },
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegisterComponent },
    ]),
    TranslateModule.forRoot({
        loader: {
            provide: TranslateLoader,
            useFactory: HttpLoaderFactory,
            deps: [HttpClient]
        }
    })
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})

export class AppModule { }

// The HttpLoaderFactory is required for AOT (ahead of time) compilation in the project
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}