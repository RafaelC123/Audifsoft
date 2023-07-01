import { HttpClient } from "@angular/common/http";
import { Component, ViewChild } from "@angular/core";
import { switchMap } from "rxjs";
import { ConfigCrud } from "src/app/components/crud-generic/config/config-crud.interface";
import { CrudGenericComponent } from "src/app/components/crud-generic/crud-generic.component";
import { Option } from "src/app/components/form-generic/config/input-config";
import { NoteInDto } from "src/app/interfaces/note/note-in-dto";
import { NoteOutDto } from "src/app/interfaces/note/note-out-dto";
import { StudentInDto } from "src/app/interfaces/student/student-in-dto";
import { StudentOutDto } from "src/app/interfaces/student/student-out-dto";
import { TeacherInDto } from "src/app/interfaces/teacher/teacher-in-dto";
import { TeacherOutDto } from "src/app/interfaces/teacher/teacher-out-dto";
import { HttpRepository } from "src/repositories/implementation/http-repository.service";

@Component({
  selector: 'app-note-component',
  templateUrl: './note.component.html',
  providers: [
    HttpRepository<NoteInDto, NoteOutDto>,
  ]
})
export class NoteComponent
{
  @ViewChild(CrudGenericComponent) crud! : CrudGenericComponent;
  configCrud : ConfigCrud;
  constructor(
    private httpRepository : HttpRepository<TeacherInDto, TeacherOutDto>,
    private teacherRepository : HttpRepository<TeacherInDto, TeacherOutDto>,
    private studentRepository : HttpRepository<TeacherInDto, TeacherOutDto>,
    private httpClient : HttpClient
    ) {
    this.studentRepository = new HttpRepository<StudentInDto, StudentOutDto>(httpClient);
    this.teacherRepository = new HttpRepository<TeacherInDto, TeacherOutDto>(httpClient);

    this.studentRepository.baseUrl += "Student/";
    this.teacherRepository.baseUrl += "Teacher/";

    const students : Option[] = [];
    const teachers : Option[] = [];
    this.studentRepository.Get().subscribe(data => {
      data.data.map(data => {
        let newOption : Option = new Option();
        newOption.text = data.name;
        newOption.value = data.id;
        students.push(newOption);
        return newOption;
      });
    });
    this.teacherRepository.Get().subscribe(data =>
      {
        data.data.map(data => {
          let newOption : Option = new Option();
          newOption.text = data.name;
          newOption.value = data.id;
          teachers.push(newOption);
          return newOption;
        });
      });
    console.log(students);
    this.httpRepository.baseUrl += "Note/";
    this.configCrud = {
      headers: [
        {
          label: "Nombre del profesor",
          propertyName: "teacherName",
        },
        {
          label: "Nombre del estudiante",
          propertyName: "studentName",
        },
        {
          label: "Nota",
          propertyName: "value",
        },
        {
          label: "Fecha de creacion",
          propertyName: "createdAt",
        }
      ],
      controls: [
        {
          label: "Valor de la nota",
          propertyName: "value",
          type: 'default'
        },
        {
          label: "Estudiante",
          propertyName: "studentId",
          type: 'select',
          valuesOptions: students
        },
        {
          label: "Profesor",
          propertyName: "teacherId",
          type: 'select',
          valuesOptions: teachers
        }
      ],
      service: this.httpRepository
    }
  }


  save(item : TeacherInDto)
  {
    console.log(item);
    this.httpRepository.Post(item)
    .subscribe(data => {
      this.crud.resetData();
    });
  }
}
