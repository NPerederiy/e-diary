import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UserProfileComponent } from './login/user-profile/user-profile.component';
import { RegisterComponent } from './register/register.component';
import { MainComponent } from './main/main.component';
import { MainMenuButtonComponent } from './main/main-menu-button/main-menu-button.component';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomePageComponent } from './main/home-page/home-page.component';
import { CalendarPageComponent } from './main/calendar-page/calendar-page.component';
import { NotesPageComponent } from './main/notes-page/notes-page.component';
import { TasksPageComponent } from './main/tasks-page/tasks-page.component';
import { TaskListComponent } from './main/tasks-page/project-page/task-list/task-list.component';
import { TaskCardComponent } from './main/tasks-page/project-page/task-list/task-card/task-card.component';
import { SidebarComponent } from './main/sidebar/sidebar.component';
import { SidebarButtonComponent } from './main/sidebar/sidebar-button/sidebar-button.component';
import { PathLineComponent } from './main/notes-page/path-line/path-line.component';
import { PathLineItemComponent } from './main/notes-page/path-line/path-line-item/path-line-item.component';
import { MalihuScrollbarModule } from 'ngx-malihu-scrollbar';
import { FolderComponent } from './main/notes-page/folder/folder.component';
import { NoteCardComponent } from './main/notes-page/folder/note-card/note-card.component';
import { CalendarMonthComponent } from './main/calendar-page/calendar-month/calendar-month.component';
import { CalendarWeekComponent } from './main/calendar-page/calendar-week/calendar-week.component';
import { CalendarDayComponent } from './main/calendar-page/calendar-day/calendar-day.component';
import { DayCardComponent } from './main/calendar-page/calendar-month/day-card/day-card.component';
import { ProjectPageComponent } from './main/tasks-page/project-page/project-page.component';
import { AccountService } from './services/account.service';
import { TokenService } from './services/token.service';
import { CategoryCardComponent } from './main/tasks-page/category-card/category-card.component';
import { ProjectCardComponent } from './main/tasks-page/project-card/project-card.component';
import { ChartsModule } from 'ng2-charts';
import { ChartLegendItemComponent } from './main/tasks-page/project-card/chart-legend-item/chart-legend-item.component';
import { AuthGuard } from './services/auth/authGuard';
import { RequestOptions } from '@angular/http';
import { AuthErrorHandler } from './services/auth/authErrorHandler';
import { AppendAuthHeader } from './services/auth/authInterceptor';
import { appRoutes } from './app.routes';
import { UserSettingsService } from './services/user-settings.service';
import { NoteFolderService } from './services/note-folder.service';
import { UserProfileService } from './services/user-profile.service';
import { NoteService } from './services/note.service';
import { FolderCardComponent } from './main/notes-page/folder/folder-card/folder-card.component';
import { FolderAddButtonComponent } from './main/notes-page/folder/folder-add-button/folder-add-button.component';
import { ProjectCategoryService } from './services/project-category.service';
import { ProjectService } from './services/project.service';

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
    TaskCardComponent,
    SidebarComponent,
    SidebarButtonComponent,
    PathLineComponent,
    PathLineItemComponent,
    FolderComponent,
    NoteCardComponent,
    CalendarMonthComponent,
    CalendarWeekComponent,
    CalendarDayComponent,
    DayCardComponent,
    ProjectPageComponent,
    CategoryCardComponent,
    ProjectCardComponent,
    ChartLegendItemComponent,
    FolderCardComponent,
    FolderAddButtonComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    MalihuScrollbarModule.forRoot(),
    ChartsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AppendAuthHeader,
      multi: true
    },
    AccountService,
    AuthGuard,
    TokenService,
    UserProfileService,
    UserSettingsService,
    NoteFolderService,
    NoteService,
    ProjectService,
    ProjectCategoryService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }

// The HttpLoaderFactory is required for AOT (ahead of time) compilation in the project
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}