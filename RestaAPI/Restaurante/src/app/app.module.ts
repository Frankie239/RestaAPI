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
import { componentFactoryName } from '@angular/compiler';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LogInComponent } from './Components/log-in/log-in.component';
import {  GuardPageService } from "src/app/Services/guard-page.service";





@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    PedidoComponent,
    ProductoComponent,
    ProductoEditorComponent,
    MesaComponent,
    MesasVisualizadorComponent,
    LogInComponent,
   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path:'clientes-listado', component: ClienteComponent,canActivate:[GuardPageService]},
      { path: 'pedidos', component: PedidoComponent, canActivate:[GuardPageService]},
      {path:'productos',component:ProductoComponent,canActivate:[GuardPageService]},
      {path:'productos/editor/:id', component:ProductoEditorComponent,canActivate:[GuardPageService]},
      {path: 'productos/editor', component:ProductoEditorComponent,canActivate:[GuardPageService]},
      {path: 'mesas',component:MesaComponent, canActivate:[GuardPageService]},
      {path:'mesas/:id', component:MesasVisualizadorComponent,canActivate:[GuardPageService]},
      { path: 'productos/agregar/:id/:mesa', component: ProductoComponent,canActivate:[GuardPageService]},
      {path:'',component:LogInComponent},
      
      

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
