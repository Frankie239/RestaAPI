import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { Imesa } from 'src/app/Models/imesa';
import {MesasService} from 'src/app/Services/mesas.service';


@Component({
  selector: 'app-mesa',
  templateUrl: './mesa.component.html',
  styleUrls: ['./mesa.component.css']
})
export class MesaComponent implements OnInit {

  public listaMesas: Imesa[] = [];
  public lastTableNumber: string = "";

  constructor(private router:Router, private Servicio: MesasService) { }

  ngOnInit(): void {

    this.Servicio.refreshNeeded$
      .subscribe(
        () => { this.CargarMesas(); }
      );
    this.CargarMesas();
    //console.log(this.listaMesas[3].pedidos[0]);
  }

     
    




  CargarViewMesaPedido(id)
  {
    this.router.navigateByUrl("/mesas/"+id);
  }

  CargarMesas(){
    this.Servicio.mostrarMesas()
    .subscribe
    (
      res => 
      { 
        this.listaMesas = res;
        //Capture the last number of a table.
        this.lastTableNumber = this.listaMesas[(this.listaMesas.length - 1)].numeroMesa;
        //Show all in console.
        console.table(this.listaMesas);

        ////console.log(this.listaMesas[3].pedidos[0].pedidoId);
      },
      
      error => console.log("Error: "+error)

    )
  }

  
  AddTable()
  {
    var lastTable: Imesa = this.listaMesas[this.listaMesas.length - 1];

    var newTable: Imesa = {
      mesaId: 0,
      numeroMesa: this.lastTableNumber,
      estado: "libre",
      pedidos: null
    };
      


    this.Servicio.PostNewTable(newTable)
      .subscribe(
        res => console.log("Agregado"),
        error => console.error("ERROR!!")
      );
     
     
  }



}
