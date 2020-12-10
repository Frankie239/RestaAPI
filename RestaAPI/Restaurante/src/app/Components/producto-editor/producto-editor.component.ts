import { Component, OnInit } from '@angular/core';
import {ProductoService} from 'src/app/Services/producto.service';
import {Iproducto} from "src/app/Models/iproducto";
import {Router, ActivatedRoute} from "@angular/router";
import { FormBuilder, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';





@Component({
  selector: 'app-producto-editor',
  templateUrl: './producto-editor.component.html',
  styleUrls: ['./producto-editor.component.css']
})
export class ProductoEditorComponent implements OnInit {

  
  formProductos:FormGroup;
  productoId:number;
  modoEdicion:boolean = false;
  productForm:Iproducto;

  constructor(private _location: Location, private service:ProductoService,private ActivatedRoute:ActivatedRoute,private router:Router,private fb:FormBuilder,)
  {
    this.ActivatedRoute.params
    .subscribe
    (
      params => 
      {
        this.productoId = params['id'];
        if(isNaN(this.productoId))
        {
          this.productForm = {
            productoId:null,
            nombre:'',
            tipo:'',
            precio:0
          }
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
              //console.table(res);
              this.cargarFormulario(res);
            },
            error => console.error(error)
          );
        }
      }
    );
    
  }

  ngOnInit() {

    this.formProductos = this.fb.group(
      {
        nombre:'',
        precio:0,
        tipo:''
      }
    );
  }


  cargarFormulario(producto:Iproducto){
    //se muestra el producto
    this.formProductos.patchValue({
      nombre:producto.nombre,
      precio:producto.precio,
      tipo:producto.tipo,
    });
    //this.save();
  }

  Save()
  {
    const productForm:Iproducto =  Object.assign({},this.formProductos.value);
    

    if(this.modoEdicion)
    {
      var newProd :Iproducto = {
        productoId:this.productoId,
        nombre:productForm.nombre,
        precio:productForm.precio,
        tipo:productForm.tipo
      };

      this.service.UpdateProd(newProd)
      .subscribe
      (
        res =>
        {
          alert("Modificado OK");
          this.GoBack();
        },
        error=> alert("error")
        
      );
    }

    else
    {
      var newProd : Iproducto={
        productoId:null,
        nombre:productForm.nombre,
        precio:productForm.precio,
        tipo:productForm.tipo
      };
      console.table(newProd);
      this.service.PostNewProd(productForm)
      .subscribe
      (
        res => { 
          console.table(res);
          this.GoBack();
        },
        error=> alert("Error")
      );


    }

  }

  DeleteProd()
  {
    this.service.DeleteProd(this.productoId)
    .subscribe
    (
      res => {
        console.log(res);
        this.GoBack();
        
      },
      error => console.error("Error al borrar"),

    );
  }

  /**
   * Returns to the last page, it was made to redirect back fast to the all products visualization
   */
  GoBack()
  {
    this._location.back();
  }
}
      


