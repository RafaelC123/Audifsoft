export class Option
{
  text!: string;
  value! : any;
}
export interface InputConfig
{
  label: string;
  propertyName : string;
  type? : 'default' | 'select';
  valuesOptions?: Option[];
}
