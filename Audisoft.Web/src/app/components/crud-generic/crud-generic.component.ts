import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from "@angular/core";
import { ConfigCrud } from "./config/config-crud.interface";
import { FromGenericComponent } from "../form-generic/form-generic.component";
import { FormGenericModule } from "../form-generic/form-generic.module";

@Component({
  selector: 'app-crud-component',
  templateUrl : './crud-generic.component.html'
})
export class CrudGenericComponent implements OnInit
{
  @ViewChild(FromGenericComponent) formComponent! : FromGenericComponent;
  @Output() saveClick : EventEmitter<any> = new EventEmitter<any>();
  @Input() Config! : ConfigCrud;
  data : any[] = [];

  ngOnInit(): void {
    this.resetData();
  }

  resetData()
  {
    this.Config.service.Get()
    .subscribe(data => {
      this.data = data.data;
    });
  }

  EditEventSet(model : any)
  {
    this.formComponent.SetValue(model);
  }

  Edit(model : any)
  {
    this.Config.service.Put(model, model.id)
    .subscribe(data => {
      this.resetData();
    });
  }

  Delete(id: any)
  {
    this.Config.service.Delete(id)
    .subscribe(data => {
      this.resetData();
    });
  }

}
