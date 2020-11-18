import { Component, OnInit } from '@angular/core';
import { Imesa } from 'src/app/Models/imesa';
import { Iproducto } from 'src/app/Models/iproducto';
import { Router } from '@angular/router';
import { MesasService } from 'src/app/Services/mesas.service';
import { ProductoService } from 'src/app/Services/producto.service';
import { ActivatedRoute } from '@angular/router';

import { Observable } from 'rxjs';



@Component({
  selector: 'app-mesas-visualizador',
  templateUrl: './mesas-visualizador.component.html',
  styleUrls: ['./mesas-visualizador.component.css']
})
export class MesasVisualizadorComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router, private ServicioMesa: MesasService, private ServicioProducto: ProductoService) { }
  //Lista de prod para mostrarlos en la tabla
  public listadoProductos: Iproducto[] = [];
  mesa: Imesa;
  pedidoId:number;
  Id:number; 
  
  ngOnInit(): void {
    
    this.listadoProductos =
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
  

  

  RedirecctionToAddingProd(id:number){
    //To DO: Hacer que cuando apretas el boton de agregar prods si no hay un pedido dentro de la lista de pedidos por mesa se agregue
    //Un pedido
    if(this.mesa.pedidos.length == 0)
    {

    }
    else
    {
      this.router.navigateByUrl("/productos/agregar/"+id+"/"+this.mesa.mesaId);
    }
    
  }

  UpdateMesaState(state:string)
  {
    
    this.mesa.estado = state;
    this.ServicioMesa.UpdateMesa(this.Id,this.mesa)
    .subscribe(
      res => console.log(res),
      error => console.error(error)
    );

  }

  
 

}
