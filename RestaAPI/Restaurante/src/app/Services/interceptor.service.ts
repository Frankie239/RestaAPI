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
    //If the user has been loggued, return his request.
    if (!user) {
      return next.handle(req);
    }
    //Else, create the request headers with the user token.
    const headers = req.clone({
      headers: req.headers.set('Authorization', 'Bearer ${user["token"]}')
    });
    
    return next.handle(headers);
  }
}
