import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';

@Injectable({
  providedIn: 'root'
})
export class ProdottoService {
  base_url:string="https://localhost:7062/Prodotto";

  constructor(private http:HttpClient) { }

  recuperaTuttiNonFiltrati():Observable<Risposta>{
    return this.http.get<Risposta>(`${this.base_url}/nonfiltrati`);
  }
}
