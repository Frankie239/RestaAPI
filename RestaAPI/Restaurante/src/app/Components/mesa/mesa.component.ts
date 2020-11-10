import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-mesa',
  templateUrl: './mesa.component.html',
  styleUrls: ['./mesa.component.css']
})
export class MesaComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }



  CargarViewMesaPedido(id)
  {
    this.router.navigateByUrl("/mesas/"+id);
  }

}
