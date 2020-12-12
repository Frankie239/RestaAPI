import { Injectable } from '@angular/core';
import {  HttpEvent, HttpHandler,HttpInterceptor, HttpRequest} from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
  {
    var user = JSON.parse(localStorage.getItem("UsuarioGuardado"));
    //If the user hasnt loggued, return his request.
    if (!user) {
      console.log("Interceptor sin usuario logueado");
      return next.handle(req);
    }
    //Else, create the request headers with the user token.
    const headers = req.clone({

      //? Why using Grave accent instead of quoutes??
      headers: req.headers.set('Authorization', `Bearer ${user["token"]}`)
    });
    console.log("Interceptor sin usuario logueado", headers);
      
    return next.handle(headers);
  }
}
