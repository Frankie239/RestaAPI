import { Component, OnInit } from '@angular/core';
import {Icliente} from 'src/app/Models/icliente';
import {IPedido} from 'src/app/Models/ipedido';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})

export class PedidoComponent implements OnInit {

  
  public listadoPedidos : IPedido[];
  //public cliente:Icliente;
  public pedido : IPedido;


  
  constructor(){}

  ngOnInit(): void {
    console.log(this.pedido);
    
    
  }


  /*
  cargarDatosHard()
  {
    for (let i = 0; i < 11; i++) {
      this.pedido.Mesa = i;
      this.pedido.PedidoId =i;
      this.listadoPedidos.push(this.pedido);
      
    }
    
  }
  */
    
   
   
   






}
