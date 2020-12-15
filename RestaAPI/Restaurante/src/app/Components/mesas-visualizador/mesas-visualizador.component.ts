import { Component, OnInit } from '@angular/core';
import { Imesa } from 'src/app/Models/imesa';
import { Iproducto } from 'src/app/Models/iproducto';
import { IPedido } from 'src/app/Models/ipedido';
import { Router } from '@angular/router';
import { MesasService } from 'src/app/Services/mesas.service';
import { ProductoService } from 'src/app/Services/producto.service';
import { ActivatedRoute } from '@angular/router';

import { Observable } from 'rxjs';
import { PedidoService } from 'src/app/Services/pedido.service';
//import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';



@Component({
  selector: 'app-mesas-visualizador',
  templateUrl: './mesas-visualizador.component.html',
  styleUrls: ['./mesas-visualizador.component.css']
})
export class MesasVisualizadorComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private ServicioMesa: MesasService, private ServicioProducto: ProductoService,private PedidoService:PedidoService) { }
  //Lista de prod para mostrarlos en la tabla
  public listadoProductos: Iproducto[] = [];
  mesa: Imesa;
  pedidoId:number;
  Id:number; 
  newPedido: Pedido = new Pedido();
  hasPedidos: boolean = false;
  TotalPrice: number = 0;
  
  ngOnInit(): void {
    
    //this.listadoProductos = 
    this.Id = this.route.snapshot.params.id;
    //Busca la mesa que le llega por la url
    
    this.ServicioMesa.MostrarUnaMesa(this.Id)
    .subscribe
    
    (
      res => {
        
        this.mesa = res;
        this.pedidoId = this.mesa.pedidos[0].pedidoId;
        
        this.ServicioProducto.productosPedidosPorId(this.pedidoId)
        .subscribe
        (
          /*Los asigno a la variable de listadoProductos*/
          res => 
          {
            this.listadoProductos = res;
            //Check if the listadoProductos contains some prods, if it's true, it should be ocuped
            if(this.listadoProductos.length > 0)
            {
              this.UpdateMesaState("ocupada");
              this.hasPedidos = true;

            }
            else
            {
              //Else: The table is free
              this.UpdateMesaState("libre");
            }
            console.table(res);
          },
          error => console.log("Error!: "+error),
        );

        
      },

      error => console.log("Error!: " + error),

      ()=>console.log("Termino de listar")
    );


    
    
    
  }
  

  /**
   * redirects to the view of producto-editor
   * 
   */

  RedirecctionToAddingProd(){
    //ToDO: Hacer que cuando apretas el boton de agregar prods si no hay un pedido dentro de la lista de pedidos por mesa se agregue Un pedido
    
    if(!this.hasPedidos)
    {
      this.mesa.pedidos.push(this.CreateNewPedido());
      
    }
    else
    {
      this.router.navigateByUrl("/productos/agregar/"+this.mesa.pedidos[0].pedidoId+"/"+this.mesa.mesaId);
    }
    
    
    
    
  }

  /**
   * Calls the service to change the state of a table
   * @param state the state-string, can be "ocupada, libre or reservada"
   */
  UpdateMesaState(state:string)
  {
    
    this.mesa.estado = state;
    this.ServicioMesa.UpdateMesa(this.Id,this.mesa)
    .subscribe(
      res => console.log(res),
      error => console.error(error)
    );

  }

  CreateNewPedido():IPedido
  {
    this.newPedido.pedidoId = 0;
    //this.newPedido.fecha = Date.now();
    this.newPedido.fecha = "2020-12-06T23:18:06";
    console.log(this.mesa.mesaId);
    this.newPedido.mesaId = this.mesa.mesaId;
    
    this.PedidoService.InsertNewPedido(this.newPedido)
    .subscribe
    (
      res =>{
        this.newPedido = res;
        this.router.navigateByUrl("/productos/agregar/"+this.newPedido.pedidoId+"/"+this.mesa.mesaId);
      },
      error => console.error(error)
      
    ); 

    return this.newPedido;


  }


  CalculateTotal()
  {
    this.listadoProductos.forEach(prod => {
      this.TotalPrice += prod.precio;
      
    });
    console.log(this.TotalPrice);

    
  }

  CloseTable()
  {
   
    this.CalculateTotal();
    alert("El total de la mesa es: " + this.TotalPrice);
    this.PedidoService.DeletePedido(this.pedidoId).subscribe(
      res => {
        console.log(res);
        
      },
      error => console.error("ERROR!")
    );
    this.UpdateMesaState("libre");
    
  }

  
 

}

class Pedido implements IPedido{
  pedidoId: number;
  fecha: any;
  mesaId: number;
}
  

