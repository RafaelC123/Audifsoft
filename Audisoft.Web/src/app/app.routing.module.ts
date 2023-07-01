import { NgModule } from "@angular/core";
import { Route, RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { TeacherComponent } from "./pages/teacher/teacher.component";
import { IndexPage } from "./pages/index.component";
import { StudentComponent } from "./pages/student/student.component";
import { NoteComponent } from "./pages/note/note.component";

const routes : Routes = [
  {
    path: '',
    component: IndexPage,
  },
  {
    path: 'teacher',
    component: TeacherComponent
  },
  {
    path: 'student',
    component: StudentComponent
  },
  {
    path: 'note',
    component: NoteComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule
{

}
