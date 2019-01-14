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

import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import {TranslateHttpLoader} from '@ngx-translate/http-loader';
import {HttpClient, HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserProfileComponent,
    RegisterComponent,
    MainComponent,
    MainMenuButtonComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent },
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegisterComponent },
      { path: '**', component: MainComponent },
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