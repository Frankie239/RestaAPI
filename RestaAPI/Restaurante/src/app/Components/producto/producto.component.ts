import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Inject, OnInit } from '@angular/core';
import {Iproducto} from 'src/app/Models/iproducto';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import {ProductoService} from 'src/app/Services/producto.service';
import {ProductoPedidoService} from 'src/app/Services/producto-pedido.service';


@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.css']
})
export class ProductoComponent implements OnInit {

  constructor(private route: ActivatedRoute,@Inject('BASE_URL') private baseUrl:string,private router: Router, private service: ProductoService,private serviceProdPedido:ProductoPedidoService) { }

 

  public products:Iproducto[];

  public IdsList:number[] = [];
  Id:string;

  ngOnInit(): void
  {

    this.Id = this.route.snapshot.params.id;
    console.log(this.Id);
    /*
    this.route.queryParams.subscribe(
      params => {
        this.Id = params['id'];
        //let mesa = params['mesa'];
        console.log(this.Id);
        //console.log(mesa);
      }
    );
    */
    

    this.service.GetAllProds()
    .subscribe
    (
      res => this.products = res,
      error => console.error(error),
    );



    
  }


    


    
  
   //creo el producto
   public prod:Iproducto;
   

  //funcion para ponerle datos
  

  CargarEditor(id:number)
  {
    this.router.navigateByUrl("/productos/editor/"+id);
  }

  CargarEditorNuevo()
  {
    this.router.navigateByUrl("/productos/editor");
  }


  GetCheckedElements(id:number,isChecked:boolean){
    //In its arguments recives the ID of the product and a boolean if it's checked

    if(isChecked)
    {
      //If it is the case of the checked being true, add it to the list
      this.IdsList.push(id);
    }
    else
    {
      const index = this.IdsList.findIndex( x => x == id);
      this.IdsList.splice(index,1);
    }

    console.table(this.IdsList);

    

      
    
  }

  AddAllSelectedProds()
  {
    if(this.IdsList.length == 0)
    {
      alert("Seleccione productos para ingresar");

    }
    else
    {
      this.IdsList.forEach(id => {
        this.serviceProdPedido.InsertProdIntoPedido(id,this.Id);
      });
    }

  }
}


  
 

