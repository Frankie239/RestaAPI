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
  listadoProductos: Iproducto[];
  mesa: Imesa;
  pedidoId:number;

  ngOnInit(): void {
    let Id = this.route.snapshot.params.id;
    //Busca la mesa que le llega por la url
    this.ServicioMesa.MostrarUnaMesa(Id)
    .subscribe
    (
      res => {
        
        this.mesa = res;
        this.pedidoId = this.mesa.pedidos[0].pedidoId;
        this.ServicioProducto.productosPedidosPorId(this.pedidoId)
        .subscribe
        (
          /*Los asigno a la variable de listadoProductos*/
          res => this.listadoProductos = res,
          error => console.log("Error!: "+error),
        );

        
      },

      error => console.log("Error!: " + error),

      ()=>console.log("Termino de listar")
    );

    
  }
  

  

  RedirecctionToAddingProd(id:number){
    this.router.navigateByUrl("/productos/agregar/"+id);
  }
 

}
