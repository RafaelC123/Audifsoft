import { GenericOutDto } from "../generic-out-dto.interface";

export interface NoteOutDto extends GenericOutDto
{
  value : number;
  studentId : number;
  teacherId: number;
  studentName : string;
  teacherName: string;
}
