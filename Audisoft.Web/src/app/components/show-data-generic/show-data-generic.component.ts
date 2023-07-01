import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { HeaderDefinition } from "./config/header-definition.interface";
import { MatTableDataSource } from "@angular/material/table";
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import { BasicDialogComponent } from "../dialogs/basic-dialog.component";

@Component({
  selector: 'app-show-data',
  templateUrl: 'show-data-generic.template.html'
})
export class ShowDataGenericComponent implements AfterViewInit, OnInit, OnChanges
{
  constructor(public dialog: MatDialog) {

  }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.Data)
    this.dataSource = new MatTableDataSource(this.Data);
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @Input() Data : any[] = [];
  @Input() headers : HeaderDefinition[] = [];

  @Output() EditEmit : EventEmitter<any> = new EventEmitter<any>();
  @Output() DeleteEmit : EventEmitter<number> = new EventEmitter<number>();

  definitions : string[] = [];
  dataSource = new MatTableDataSource(this.Data);


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.Data);
    this.definitions = this.headers.map((x) => x.propertyName);
    this.definitions.push("acciones")
  }

  Delete(id : any)
  {
    var result = this.dialog.open(BasicDialogComponent, {
      width: '350px',
    });
    result.afterClosed().subscribe(data => {
      if(data == "Ok")
      {
        this.DeleteEmit.emit(id);
      }
    });
  }
}
