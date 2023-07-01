import { NgModule, ViewChild } from "@angular/core";
import { ShowDataGenericComponent } from "./show-data-generic.component";
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import {CommonModule} from '@angular/common';

import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatButtonModule } from "@angular/material/button";
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { BasicDialogModule } from "../dialogs/basic-dialog.module";

@NgModule({
  declarations: [
    ShowDataGenericComponent
  ],
  imports: [
    MatTableModule,
    MatPaginatorModule,
    CommonModule,
    MatButtonModule,
    MatDialogModule,
    BasicDialogModule
  ],
  exports: [
    ShowDataGenericComponent
  ],
})

export class ShowDataGenericModule
{


}
