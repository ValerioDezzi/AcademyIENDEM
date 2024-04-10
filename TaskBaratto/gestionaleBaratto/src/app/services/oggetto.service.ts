import { Injectable } from '@angular/core';
import { Oggetto } from '../models/oggetto';

@Injectable({
  providedIn: 'root'
})
export class OggettoService {

  private elencoOggetti:Oggetto[]=new Array();

  constructor() { }

  recuperaOggetti():Oggetto[]{
    return this.elencoOggetti
  }

  inserisciOggetto(objOgg:Oggetto):boolean{
   if(objOgg){
    this.elencoOggetti.push(objOgg);
    return true;
   } 
   return false;
  }
}


