import { Component, OnInit } from '@angular/core';
import {ProductoService} from 'src/app/Services/producto.service';
import {Iproducto} from "src/app/Models/iproducto";
import {Router, ActivatedRoute} from "@angular/router";
import {FormBuilder,FormGroup}from '@angular/forms';
import { Console } from 'console';


@Component({
  selector: 'app-producto-editor',
  templateUrl: './producto-editor.component.html',
  styleUrls: ['./producto-editor.component.css']
})
export class ProductoEditorComponent implements OnInit {

  
  formProductos:FormGroup;
  productoId:number;
  modoEdicion:boolean = false;

  constructor(private service:ProductoService,private ActivatedRoute:ActivatedRoute,private router:Router,private fb:FormBuilder,)
  {
    this.ActivatedRoute.params
    .subscribe
    (
      params => 
      {
        this.productoId = params['id'];
        if(isNaN(this.productoId))
        {
          return;
        }
        else
        {
          this.modoEdicion = true;
          this.service.GetProdById(this.productoId)
          .subscribe
          (
            res => 
            {
              console.table(res);
              this.cargarFormulario(res);
            },
            error => console.error(error)
          )
        }
      }
    )
    
  }

  ngOnInit(): void {

    this.formProductos = this.fb.group(
      {
        prodName:'',
        prodPrice:0,
        prodType:''
      }
    );
  }


  cargarFormulario(producto:Iproducto){
    //se muestra el producto
    this.formProductos.patchValue({
      prodName:producto.nombre,
      prodPrice:producto.precio,
      prodType:producto.tipo,
    });
    //this.save();
  }
}
      


