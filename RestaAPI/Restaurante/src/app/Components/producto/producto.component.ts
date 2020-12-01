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

 

  public products: Iproducto[];
  public productsSearch: Iproducto[] = [];
  public searchMode: boolean = false;

  public IdsList:number[] = [];
  Id:string;
  mesa:string;


  ngOnInit(): void
  {

    this.Id = this.route.snapshot.params.id;
    this.mesa = this.route.snapshot.params.mesa;
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
   console.log(this.mesa);
    

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
    this.ReturnToMesaVisualizador();

  }

  ReturnToMesaVisualizador()
  {
    this.router.navigateByUrl("/mesas/"+this.mesa);
  }

  //TODO: Hacer que filtre los productos
  Buscar()
  {
    this.productsSearch = [];
    this.searchMode = true;
    var input, filter:string, tableRow:any,nameText:string, txtValue;
    //Get the element that has the value to search
    input = document.getElementById("myInput");
    //grab the text
    filter = input.value.toUpperCase();
    //TEST: console.log(filter)
    var regex = new RegExp("(" + filter + ")", "gmi");
    console.log(regex);

    
   
    
    /////const regex = /(pescado)/gmi;
    this.products.forEach(prod => {
      if (regex.test(prod.nombre) && !this.productsSearch.includes(prod))
      {
        this.productsSearch.push(prod);
        console.table(this.productsSearch);
      }
      
    });
    //this.productsSearch = [];
    //console.table(this.products);

    /*
    ! Old code
    for (i = 0; i < li.length; i++) {


      
        a = li[i].getElementsByTagName("p")[0];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
      
    }
    */
}
}


  
 

