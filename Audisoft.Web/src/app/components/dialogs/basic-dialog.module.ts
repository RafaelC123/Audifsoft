import { NgModule } from "@angular/core";
import { BasicDialogComponent } from "./basic-dialog.component";
import { MatButton, MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";

@NgModule({
  imports: [
    MatButtonModule,
    MatDialogModule
  ],
  exports: [
    BasicDialogComponent
  ],
  declarations: [
    BasicDialogComponent
  ]
})
export class BasicDialogModule
{

}
