import { Injectable, Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../_models/Cliente';

@Injectable()
export class ClienteService {

baseURL = 'http://localhost:63761/api/cliente';

// prod
// baseURL = 'http://diegomulet.eastus.cloudapp.azure.com/ProaAgilAPI/api/cliente';

constructor(private http: HttpClient) {}

getAllCliente(): Observable<Cliente[]>  {
   return this.http.get<Cliente[]>(this.baseURL);
}

getClienteById(id: number): Observable<Cliente>  {
  return this.http.get<Cliente>(`${this.baseURL}/${id}`);
}

postCliente(cliente: Cliente) {
  return this.http.post(this.baseURL, cliente);
}

// postUpload(file: File, name: string) {

//   const fileToUpload = <File>file[0];
//   const formData = new FormData();

//   formData.append('file', fileToUpload, name);
//   return this.http.post(`${this.baseURL}/upload`, formData);
// }

putCliente(cliente: Cliente) {
  return this.http.put(`${this.baseURL}/${cliente.Id}`, cliente);
}

deleteCliente(id: string) {
  return this.http.delete(`${this.baseURL}/${id}`);
}

}
