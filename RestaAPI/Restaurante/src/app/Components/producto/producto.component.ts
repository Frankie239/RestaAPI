import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import {Iproducto} from 'src/app/Models/iproducto';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  constructor(private route: ActivatedRoute,@Inject('BASE_URL') private baseUrl:string,private router: Router) { }

 

  

  ngOnInit(): void {

    this.route.queryParams.subscribe(
      params => {
        let Id = params['Id'];
        console.log(Id);
      }
    );
    //llamo a la funcion
    this.datosHard();
  }
  
   //creo el producto
   public prod:Iproducto;
   

  //funcion para ponerle datos
  datosHard()
  {
    
    this.prod.nombre ="Productito";
    this.prod.precio=200;
    this.prod.productoId =1;
    this.prod.tipo="productos general";
    console.table(this.prod);
  }

  CargarEditor(id:number)
  {
    this.router.navigateByUrl("/productos/editor/"+id);
  }

  CargarEditorNuevo()
  {
    this.router.navigateByUrl("/productos/editor");
  }


  
  listaIds = 
  [
   {
      id:1
   },
   {
      id:2
   },
   {
      id:3
   }

    
  ];
  

}
