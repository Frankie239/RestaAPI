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

  PostNewProd(product:Iproducto):Observable<void>
  {
    const headers = {
      'Content-Type':'application/json',
      'Access-Control-Allow-Origin':'*',
      'Access-Control-Allow-Methods':'POST, PUT,GET,DELETE',
    };
    return this.http.post<void>(this.apiUrl,product,{headers});
  }

  UpdateProd(product:Iproducto)
  {
    const headers = {
      'Content-Type':'application/json',
      'Access-Control-Allow-Origin':'http://localhost:5000',
      'Access-Control-Allow-Methods':'POST, PUT,GET,DELETE',
    };
    return this.http.put<any>(this.apiUrl+"/"+product.productoId,product,{headers});
  }

  DeleteProd(id:number):Observable<Iproducto>
  {
    return this.http.delete<Iproducto>(this.apiUrl+"/"+id);
  }



  
}