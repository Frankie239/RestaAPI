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
    return this.http.post<IPedido>(this.apiUrl,pedido,{headers});
  }

  InsertPedidoWithId(pedido:IPedido,Id:number):Observable<IPedido>
  {
    pedido.mesaId = Id;

    //? This does not exists!
    //return this.http.post<IPedido>(this.apiUrl + "/mesa/" + Id, pedido);

    return this.http.post<IPedido>(this.apiUrl,pedido);
    
    
  }

  //Services: 

  //Request total of request. 

  /**
   * Gets the total facturation of a request,
   * @param pedidoId 
   * @returns the total facturation(number)
   */
  GetTotalFacturation(pedidoId: number):number
  {
    return 0
  }

  /**
   * Deletes a Request calling this endpoint
   * DELETE: api/pedido/{id}
   * 
   * @param pedidoId  int the id of the request to delete.
   */
  //Delete request 
  DeletePedido(pedidoId: number)
  {
    return this.http.delete<any>(this.apiUrl + "/" + pedidoId);
  }
  

  //Delete all the prods into the intermediate table.

  
}