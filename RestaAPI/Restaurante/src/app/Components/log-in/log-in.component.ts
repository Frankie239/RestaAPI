import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from "@angular/forms";
import { IUser } from 'src/app/Models/iuser';
import { LogInService } from "src/app/Services/log-in.service";

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  LoginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private AuthService:LogInService
  ) { }

  ngOnInit(): void {

    this.LoginForm = this.formBuilder.group(
      {
        userName: "",
        password: ""
      }
    );
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
  
  Loguear()
  {
    let usuarioFormulario: IUser = Object.assign({}, this.LoginForm.value);

   
    this.AuthService.LogIn(usuarioFormulario.userName,usuarioFormulario.password)
      .subscribe(
        res => {
          console.log(res);
        },
        error => console.error("ERROR!", error)
      )
  }
  

}
