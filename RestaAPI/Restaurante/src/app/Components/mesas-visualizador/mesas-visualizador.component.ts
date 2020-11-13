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
  listadoProductos: Iproducto[]
  mesa: Imesa;

  ngOnInit(): void {
    let Id = this.route.snapshot.params.id;
    this.MostrarProdPorMesa(Id);
  }
  

  MostrarProdPorMesa(id) {


    //Busca la mesa que le llega por la url
    this.mesa = this.mostrarMesa(id);

    //Control


    //De la mesa extraigo el id del pedido
    let pedidoId = this.mesa.pedidos[0].pedidoId;



    //busco en productoPedidos los prods

    this.ServicioProducto.productosPedidosPorId(pedidoId)
    .subscribe
    (
      /*Los asigno a la variable de listadoProductos*/
      res => this.listadoProductos = res,
      error => console.log("Error!: "+error)
    );




    
  }

  mostrarMesa(id): Imesa {

    this.ServicioMesa.MostrarUnaMesa(id)
      .subscribe
      (
        res => {
          console.log(res);
          this.mesa = res;
        },
        error => console.log("Error!: " + error),

      )
    return null;
  }

}
