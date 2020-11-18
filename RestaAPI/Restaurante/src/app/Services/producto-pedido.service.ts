import { Injectable, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Iproducto} from 'src/app/Models/iproducto';

@Injectable({
  providedIn: 'root'
})
export class ProductoPedidoService {

  private apiUrl:string = this.baseUrl + "api/Producto";


  constructor(@Inject('BASE_URL') private baseUrl:string ,private http:HttpClient) { }

  GetProds():Observable<Iproducto[]>
  {
    return this.http.get<Iproducto[]>(this.apiUrl);
  }

  GetProdById(id:number):Observable<Iproducto>
  {
    return this.http.get<Iproducto>(this.apiUrl+"/"+id)
  }

  InsertProdIntoPedido(ProdId:number,PedidoId:any){
    
    PedidoId = parseInt(PedidoId);
    
    
    return this.http.post(this.apiUrl +"/"+ProdId+"/pedido/"+PedidoId,null).subscribe();
    
    
  }

}
