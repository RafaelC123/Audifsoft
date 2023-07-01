import { TypeMessage } from "../enums/type-message.enum";

export interface Status<T>
{
  message : string;
  typeMessage : TypeMessage;
  data : T;
}
