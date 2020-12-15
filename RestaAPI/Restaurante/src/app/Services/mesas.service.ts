import { Injectable, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
//import {inject} from '@angular/core/testing';
import {Imesa} from '../Models/imesa';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MesasService {

  

  private apiUrl:string = this.baseUrl + "api/mesa";


  constructor(@Inject('BASE_URL') private baseUrl:string ,private http:HttpClient) { }

  mostrarMesas(): Observable<Imesa[]>
  {
    return this.http.get<Imesa[]>(this.apiUrl);
  }

  MostrarUnaMesa(id:number): Observable<Imesa>
  {
    return this.http.get<Imesa>(this.apiUrl+"/"+id);
  }

  UpdateMesa(id:number, mesa:Imesa):Observable<Imesa>
  {
    return this.http.put<Imesa>(this.apiUrl+"/"+id,mesa);
  }

  PostNewTable(table:Imesa)
  {
    return this.http.post<Imesa>(this.apiUrl, table);
  }

}
