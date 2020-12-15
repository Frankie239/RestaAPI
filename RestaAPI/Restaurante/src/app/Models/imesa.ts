import {IPedido} from 'src/app/Models/ipedido';

export interface Imesa {
    mesaId:number,
    numeroDeMesa:string,
    estado:string,
    pedidos:IPedido[],
}

