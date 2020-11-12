import { BrowserModule } from '@angular/platform-browser';
import { Component, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './Components/cliente/cliente.component';
import { RouterModule } from '@angular/router';
import { PedidoComponent } from './Components/pedido/pedido.component';
import { ProductoComponent } from './components/producto/producto.component';
import { ProductoEditorComponent } from './Components/producto-editor/producto-editor.component';
import { MesaComponent } from './Components/mesa/mesa.component';
import { MesasVisualizadorComponent } from './Components/mesas-visualizador/mesas-visualizador.component';
import { ProbandoComponent } from './Components/probando/probando.component';




@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    PedidoComponent,
    ProductoComponent,
    ProductoEditorComponent,
    MesaComponent,
    MesasVisualizadorComponent,
    ProbandoComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path:'clientes-listado', component: ClienteComponent},
      {path:'pedidos',component: PedidoComponent},
      {path:'productos',component:ProductoComponent},
      {path:'productos/editor/:id', component:ProductoEditorComponent},
      {path: 'productos/editor', component:ProductoEditorComponent},
      {path: 'mesas',component:MesaComponent},
      {path:'mesas/:id', component:MesasVisualizadorComponent},
      {path:'testing', component:ProbandoComponent},
      

    ])
  ],
  providers: [
    {provide: 'BASE_URL', useFactory: getBaseUrl}

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl(){
  
  return document.getElementsByTagName('base')[0].href;
}
