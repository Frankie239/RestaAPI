import { Component, OnInit } from '@angular/core';
import {ClienteService}from 'src/app/Services/cliente.service';
import {Icliente} from 'src/app/Models/icliente';
//import { timingSafeEqual } from 'crypto';
@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {

  public listClientes : Icliente[];

  constructor( private Servicio: ClienteService) { }

  ngOnInit(): void {

    this.mostratTodos();

  }

  mostratTodos()
  {
    this.Servicio.mostrarTodos()
    .subscribe
    (
      resultado =>
      {
        this.listClientes = resultado
        console.table(resultado)

      },
      error => console.error(error)
    )
  }

}
