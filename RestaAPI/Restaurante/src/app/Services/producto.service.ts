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
 
  productosPedidosPorId(id):Observable<Iproducto[]>
  {
    return this.http.get<Iproducto[]>(this.apiUrl+"/pedido/"+id);
  }
  
}