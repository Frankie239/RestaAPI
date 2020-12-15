import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms";
import { IUser } from 'src/app/Models/iuser';
import { LogInService } from "src/app/Services/log-in.service";
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  LoginForm: FormGroup;
  returnUrl: string;
  logInFlag: boolean;

  constructor(
    private formBuilder: FormBuilder,
    public AuthService: LogInService,
    private router: Router,
    private ActivatedRoute: ActivatedRoute,
  )
  {
    this.logInFlag = AuthService.IsLogged();
  }

  
  

  ngOnInit(): void {

    //Every time the log in component loads, logs out the actual user
    if (this.AuthService.IsLogged)
    {
      this.AuthService.LogOut();
      this.logInFlag = false;
    }
    this.LoginForm = this.formBuilder.group(
      {
        userName: "",
        password: ""
        
      }
    );

    this.returnUrl = this.ActivatedRoute.snapshot.queryParams["returnUrl"] || '/';

    

  }



  CargarFormulario(usuario: IUser)
  {
    this.LoginForm.patchValue(
      {
        userName: usuario.userName,
        password:usuario.password
      }
    )
  }

  /**
   * calls the service to log you into the page. if you are not logged in, 
   * you cant access all the other components that are about management.
   * 
   * 
   */
  
  Loguear()
  {
    let usuarioFormulario: IUser = Object.assign({}, this.LoginForm.value);

    this.logInFlag = true;
    this.AuthService.LogIn(usuarioFormulario.userName,usuarioFormulario.password)
      .subscribe(
        res => {
          /*console.log(res);*/
          this.router.navigate(["/mesas"]);
        },
        error => console.error("ERROR!", error)
      )
  }

  LogOut()
  {
    console.log("Cerrando");
    this.AuthService.LogOut();
    this.logInFlag = false;
  }
  

}
