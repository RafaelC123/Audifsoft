import { NgModule, ViewChild } from "@angular/core";
import {CommonModule} from '@angular/common';
import { MatCardModule } from "@angular/material/card";
import { FromGenericComponent } from "./form-generic.component";
import { MatFormFieldModule } from "@angular/material/form-field";
import {MatIconModule} from '@angular/material/icon';
import {MatInputModule} from '@angular/material/input';
import { FormsModule } from "@angular/forms";
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';


@NgModule({
  declarations: [
    FromGenericComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatSelectModule
  ],
  exports: [
    FromGenericComponent
  ],
})

export class FormGenericModule
{


}
