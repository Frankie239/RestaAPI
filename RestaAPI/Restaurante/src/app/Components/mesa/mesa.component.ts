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

  public listaMesas:Imesa[];

  constructor(private router:Router, private Servicio: MesasService) { }

  ngOnInit(): void {
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
        console.table(this.listaMesas);
        console.log(this.listaMesas[3].pedidos[0].pedidoId);
      },
      
      error => console.log("Error: "+error)

    )
  }



}
