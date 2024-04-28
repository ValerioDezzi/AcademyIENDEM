import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Risposta } from '../models/risposta';

@Injectable({
  providedIn: 'root'
})
export class GiocatoreService {
  base_url:string="https://localhost:7018/Giocatore";

  constructor(private http: HttpClient) { }

  recuperaTutti():Observable<Risposta>{
    return this.http.get<Risposta>(`${this.base_url}/listagiocatori`);
  }
}
