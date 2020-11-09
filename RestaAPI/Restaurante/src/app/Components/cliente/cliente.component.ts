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

  listClientes :Icliente[];

  constructor( private Servicio: ClienteService) { }

  ngOnInit(){

    this.MostrarListado();
    console.table(this.listClientes);

  }

  MostrarListado()
  {
    this.Servicio.mostrarTodos()
    .subscribe
    (
      resultado =>
      {
        this.listClientes = resultado;
        let x = this.listClientes.length;
        console.table(resultado);
        return this.listClientes;

      },
      error => console.error(error)
    );
  }

}
