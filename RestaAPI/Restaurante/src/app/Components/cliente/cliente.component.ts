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
  constructor( private Servicio: ClienteService) { }

  listClientes :Icliente[];

  

  ngOnInit(){

    this.MostrarListado();

    console.table(this.listClientes)
    

  }

  MostrarListado()
  {
    this.Servicio.mostrarTodos()
    .subscribe
    (
      res =>
      {
        this.listClientes = res;
        console.table(this.listClientes);
      },
      error => console.error(error)
    );
  }
        
        
        


}
