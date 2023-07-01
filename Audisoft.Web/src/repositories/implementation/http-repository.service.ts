import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable, map } from "rxjs";
import { Status } from "src/app/interfaces/status-dto.interface";

@Injectable({
  providedIn: 'root'
})
export class HttpRepository<InDto, OutDto>
{
  baseUrl : string;
  headers : HttpHeaders;
  constructor(private httpClient : HttpClient) {
    this.baseUrl = "http://localhost:5017/Api/";
    this.headers = new HttpHeaders({"x-version" : "v1"});
  }
  Get(url: string = "") : Observable<Status<OutDto[]>>
  {
    return this.httpClient.get<Status<OutDto[]>>((this.baseUrl + url ?? ""), {headers: this.headers})
    .pipe(map(((data : Status<OutDto[]>) => data)));
  }

  Post(entity : InDto, url: string = "") : Observable<Status<OutDto>>
  {
    return this.httpClient.post<Status<OutDto>>((this.baseUrl + url ?? ""), entity, {headers: this.headers})
    .pipe(
      map((data => data))
      );
  }

  Put(entity : InDto, id: number, url: string = "") : Observable<Status<OutDto>>
  {
    return this.httpClient.put<Status<OutDto>>((`${this.baseUrl + url ?? ""}${id}`), entity, {headers: this.headers})
    .pipe(map((data => data)));
  }

  Delete(id: number, url: string = "") : Observable<Status<OutDto>>
  {
    return this.httpClient.delete<Status<OutDto>>((`${this.baseUrl + url ?? ""}${id}`), {headers: this.headers})
    .pipe(map((data => data)));
  }
}

