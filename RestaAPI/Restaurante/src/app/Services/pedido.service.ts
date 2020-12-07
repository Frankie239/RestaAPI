import { Injectable,Inject  } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {IPedido} from 'src/app/Models/ipedido';
@Injectable({
  providedIn: 'root'
})
export class PedidoService {
  private apiUrl:string = this.baseUrl + "api/pedido";

  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) { }
  
 
  //Agregar metodo en el servicio para agregar un pedido
  InsertNewPedido(pedido:IPedido):Observable<IPedido>
  {
    return this.http.post<IPedido>(this.apiUrl,pedido);
  }
  InsertPedidoWithId(pedido:IPedido,Id:number):Observable<IPedido>
  {
    pedido.mesa = Id;

    //? This does not exists!
    //return this.http.post<IPedido>(this.apiUrl + "/mesa/" + Id, pedido);

    return this.http.post<IPedido>(this.apiUrl,pedido);
    
    
  }
}