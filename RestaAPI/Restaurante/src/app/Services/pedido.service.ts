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
    const headers = {
      'Content-Type':'application/json',
      'Access-Control-Allow-Origin':'*',
      'Access-Control-Allow-Methods':'POST, PUT,GET,DELETE',
    };
    console.log(pedido);
    return this.http.post<any>(this.apiUrl,pedido,{headers});
  }
  InsertPedidoWithId(pedido:IPedido,Id:number):Observable<IPedido>
  {
    pedido.mesaId = Id;

    //? This does not exists!
    //return this.http.post<IPedido>(this.apiUrl + "/mesa/" + Id, pedido);

    return this.http.post<IPedido>(this.apiUrl,pedido);
    
    
  }

  //ToDO: When you click on "cerrar mesa" it must show you the total cost of that table and the delete the order
  DeletePedido(pedidoId:number)
  {

  }
}