import { Component, ViewChild } from "@angular/core";
import { ConfigCrud } from "src/app/components/crud-generic/config/config-crud.interface";
import { CrudGenericComponent } from "src/app/components/crud-generic/crud-generic.component";
import { StudentInDto } from "src/app/interfaces/student/student-in-dto";
import { StudentOutDto } from "src/app/interfaces/student/student-out-dto";
import { TeacherInDto } from "src/app/interfaces/teacher/teacher-in-dto";
import { TeacherOutDto } from "src/app/interfaces/teacher/teacher-out-dto";
import { HttpRepository } from "src/repositories/implementation/http-repository.service";

@Component({
  selector: 'app-student-component',
  templateUrl:'./student.component.html',
  providers: [HttpRepository<StudentInDto, StudentOutDto>]
})
export class StudentComponent
{
  @ViewChild(CrudGenericComponent) crud! : CrudGenericComponent;
  configCrud : ConfigCrud;
  constructor(private httpRepository : HttpRepository<StudentInDto, StudentOutDto>) {
    this.httpRepository.baseUrl += "Student/";
    this.configCrud = {
      headers: [
        {
          label: "Nombre del estudiante",
          propertyName: "name",
        },
        {
          label: "Fecha de creacion",
          propertyName: "createdAt",
        }
      ],
      controls: [
        {
          label: "Nombre",
          propertyName: "name",
          type: 'default'
        }
      ],
      service: this.httpRepository
    }
  }


  save(item : StudentInDto)
  {
    console.log(item);
    this.httpRepository.Post(item)
    .subscribe(data => {
      this.crud.resetData();
    });
  }
}
