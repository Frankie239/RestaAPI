import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import {  LogInService } from "src/app/Services/log-in.service";

@Injectable({
  providedIn: 'root'
})
export class GuardPageService implements CanActivate{

  constructor(private service:LogInService, private rotuer:Router) { }

  canActivate() {
    
    if (!this.service.IsLogged())
    {
      console.log("Not Logged");
      this.rotuer.navigate(['/']);

      return false
    }
    else return true
  }
}
