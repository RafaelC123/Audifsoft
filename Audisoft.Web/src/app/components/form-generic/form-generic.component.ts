import { Component, EventEmitter, Input, Output } from "@angular/core";
import { InputConfig } from "./config/input-config";

@Component({
  selector: 'app-form-generic',
  templateUrl: './form-generic.component.html'
})
export class FromGenericComponent
{
  private idEdit : number = 0;
  @Output() Save : EventEmitter<any> = new EventEmitter<any>();
  @Output() Edit : EventEmitter<any> = new EventEmitter<any>();
  @Input() Configs : InputConfig[] = [];
  public model : any = {};
  constructor() {

  }


  SetValue(newModel : any)
  {
    console.log(newModel["id"])
    this.idEdit = newModel["id"];
    this.model = newModel;
  }


  SaveClick()
  {
    if(this.idEdit > 0)
    {
      this.Edit.emit(this.model);
      this.idEdit = 0;
      this.model = {};

      return;
    }
    this.Save.emit(this.model);
    this.model = {};
  }
}
