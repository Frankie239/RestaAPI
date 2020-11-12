import {IPedido} from 'src/app/Models/ipedido';

export interface Imesa {
    mesaId:number,
    numeroMesa:string,
    estado:string,
    pedidos:IPedido[],
}

