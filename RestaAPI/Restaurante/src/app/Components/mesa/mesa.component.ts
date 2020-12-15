import { stringify } from '@angular/compiler/src/util';
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
  public lastTableNumber: number = 0;
  

  constructor(private router:Router, private Servicio: MesasService) { }

  ngOnInit(): void {

    this.Servicio.refreshNeeded$
      .subscribe(
        () => { this.CargarMesas(); }
      );
    this.CargarMesas();
    ////console.log(this.listaMesas[3].pedidos[0]);
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
        //Capture the last number of a table and add one to the number(To later add a new one).
        // this is being used on the AddTable()
        this.lastTableNumber = parseInt(this.listaMesas[(this.listaMesas.length - 1)].numeroDeMesa) + 1 ;
        
        //Show all in console.
        console.table(this.listaMesas);
        console.table(this.lastTableNumber);

        ////console.log(this.listaMesas[3].pedidos[0].pedidoId);
      },
      
      error => console.log("Error: "+error)

    )
  }

  /**
   * Adds a new table with the last number +1.
   */
  AddTable()
  {
    var lastTable: Imesa = this.listaMesas[this.listaMesas.length - 1];

    //Assign the captured number on the onInit part of the component.
    var newTable: Imesa = {
      mesaId: 0,
      numeroDeMesa:  this.lastTableNumber.toString(),
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
