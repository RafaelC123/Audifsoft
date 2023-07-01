import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSidenavModule} from '@angular/material/sidenav';
import { AppRoutingModule } from './app.routing.module';
import { CrudGenericModule } from './components/crud-generic/crud-generic.module';
import { TeacherComponent } from './pages/teacher/teacher.component';
import {MatCardModule} from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http';
import { IndexPage } from './pages/index.component';
import {MatListModule} from '@angular/material/list';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import { StudentComponent } from './pages/student/student.component';
import { NoteComponent } from './pages/note/note.component';

@NgModule({
  declarations: [
    AppComponent,
    TeacherComponent,
    StudentComponent,
    NoteComponent,
    IndexPage
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,


    MatSidenavModule,
    MatFormFieldModule,
    MatSelectModule,
    MatButtonModule,
    MatCardModule,
    HttpClientModule,
    MatListModule,
    MatToolbarModule,
    MatIconModule,


    AppRoutingModule,
    CrudGenericModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
