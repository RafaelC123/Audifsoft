import { HttpRepository } from "src/repositories/implementation/http-repository.service";
import { HeaderDefinition } from "../../show-data-generic/config/header-definition.interface";
import { InputConfig } from "../../form-generic/config/input-config";

export interface ConfigCrud
{
  headers: HeaderDefinition[];
  controls : InputConfig[];
  service : HttpRepository<any, any>;
}
