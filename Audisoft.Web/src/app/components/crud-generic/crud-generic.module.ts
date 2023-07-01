import { NgModule } from "@angular/core";
import { CrudGenericComponent } from "./crud-generic.component";
import { ShowDataGenericModule } from "../show-data-generic/show-data-generic.module";
import { FormGenericModule } from "../form-generic/form-generic.module";
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

@NgModule({
  declarations: [
    CrudGenericComponent
  ],
  imports: [
    ShowDataGenericModule,
    FormGenericModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule
  ],
  exports: [
    CrudGenericComponent
  ]
})
export class CrudGenericModule
{

}
