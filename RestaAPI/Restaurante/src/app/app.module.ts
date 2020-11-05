import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './Components/cliente/cliente.component';
import { RouterModule } from '@angular/router';
import { PedidoComponent } from './Components/pedido/pedido.component';




@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    PedidoComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      {path:'clientes-listado', component: ClienteComponent},
      {path:'pedidos',component: PedidoComponent}

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
