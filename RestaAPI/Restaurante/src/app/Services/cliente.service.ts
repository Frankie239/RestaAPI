import { Injectable, Inject} from '@angular/core';
import {Icliente} from '../Models/icliente';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { inject } from '@angular/core/testing';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  public listaClientes : Icliente[];
  public baseUrl:string = "http://localhost:5000/";
  private apiUrl:string = this.baseUrl+ "api/cliente";



  constructor( private http:HttpClient) { }

  mostrarTodos(): Observable<Icliente[]>
  {

    const headers =
    {
      "Accept":'application/json'
    }

    return this.http.get<Icliente[]>(this.apiUrl);
  }

}
