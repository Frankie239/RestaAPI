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
          return response;
        })
      );
    


  }

  
}
