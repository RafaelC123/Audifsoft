import { Component, ViewChild } from "@angular/core";
import { switchMap } from "rxjs";
import { ConfigCrud } from "src/app/components/crud-generic/config/config-crud.interface";
import { CrudGenericComponent } from "src/app/components/crud-generic/crud-generic.component";
import { TeacherInDto } from "src/app/interfaces/teacher/teacher-in-dto";
import { TeacherOutDto } from "src/app/interfaces/teacher/teacher-out-dto";
import { HttpRepository } from "src/repositories/implementation/http-repository.service";

@Component({
  selector: 'app-teacher-component',
  templateUrl: './teacher.component.html',
  providers: [HttpRepository<TeacherInDto, TeacherOutDto>]
})
export class TeacherComponent
{
  @ViewChild(CrudGenericComponent) crud! : CrudGenericComponent;
  configCrud : ConfigCrud;
  constructor(private httpRepository : HttpRepository<TeacherInDto, TeacherOutDto>) {
    this.httpRepository.baseUrl += "Teacher/";
    this.configCrud = {
      headers: [
        {
          label: "Nombre del profesor",
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


  save(item : TeacherInDto)
  {
    console.log(item);
    this.httpRepository.Post(item)
    .subscribe(data => {
      this.crud.resetData();
    });
  }
}
