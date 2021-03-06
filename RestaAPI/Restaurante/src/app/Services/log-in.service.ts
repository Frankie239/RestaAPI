import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from "rxjs";

import { map } from 'rxjs/operators';

import { IUser } from '../Models/iuser';



@Injectable({
  providedIn: 'root'
})
export class LogInService {

  public actualUser: Observable<IUser>;

  //Api URL
  private apiUrl:string = this.baseUrl + "api/login";


  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) { }
  /**
   * logs you in into the page.
   * @param userName the username, string
   * @param password the password, no encryption yet
   * @returns  a token and the user that is logged
   */

  LogIn(userName: string, password: string)
  {
    const ApiUser: IUser =
    {
      userId: 0,
      userName: userName,
      password: password,
      fullName: "",
      userRole: "",
      token: ""
    };

    
    return this.http.post<any>(this.apiUrl, ApiUser)
      .pipe(
        map(response => {
          console.log(response);
          localStorage.setItem('UsuarioGuardado', JSON.stringify(response));
          return response;
        })
      );
    


  }
  IsLogged()
  {
    var logged = false;
    var user = JSON.parse(localStorage.getItem('UsuarioGuardado'));
    if (user)
    {
      const token = user["token"];
      console.log(token);
      logged = true;
    }
    return logged;
    

  }

  LogOut() {
    localStorage.removeItem('UsuarioGuardado');
  }

  
}
