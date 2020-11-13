import { Injectable,Inject  } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Iproducto} from 'src/app/Models/iproducto';
@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  private apiUrl:string = this.baseUrl + "api/pedido";

  constructor(@Inject('BASE_URL') private baseUrl:string ,private http:HttpClient) { }
 

}