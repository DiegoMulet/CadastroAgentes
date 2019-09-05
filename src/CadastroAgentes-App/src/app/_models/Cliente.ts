import { Status } from './Status';

export class Cliente {
    Id: string;
    Nome: string;
    Endereco: string;
    DataNascimento: Date;
    Altura: number;
    Peso: number;
    Status?: Status;
    UsuarioAnalise?: string;
    DataTerminoAnalise?: Date;
}
