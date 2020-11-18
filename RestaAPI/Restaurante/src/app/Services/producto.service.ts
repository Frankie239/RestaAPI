import { Injectable,Inject  } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Iproducto} from 'src/app/Models/iproducto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  private apiUrl:string = this.baseUrl + "api/producto";

  constructor(@Inject('BASE_URL') private baseUrl:string ,private http:HttpClient) { }

  //Return all the products
  GetAllProds():Observable<Iproducto[]>
  {
    return this.http.get<Iproducto[]>(this.apiUrl);
  }

  //Returns a product bi it's primary key
  GetProdById(id):Observable<Iproducto>
  {
    return this.http.get<Iproducto>(this.apiUrl+"/"+id);
  }
 
  //Returns all the products in a order
  productosPedidosPorId(id):Observable<Iproducto[]>
  {
    return this.http.get<Iproducto[]>(this.apiUrl+"/pedido/"+id);

  }

  //Adding a prod to a order OUTDATED

  addProductoPedido(ProdId:number, PedidoId:number)
  {
    //this.http.post<any>(this.apiUrl+"/"+ProdId+"/pedido"+PedidoId);
  }



  
}