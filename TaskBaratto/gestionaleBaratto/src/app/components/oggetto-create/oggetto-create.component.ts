import { Component } from '@angular/core';
import { OggettoService } from '../../services/oggetto.service';
import { Oggetto } from '../../models/oggetto';

@Component({
  selector: 'app-oggetto-create',
  templateUrl: './oggetto-create.component.html',
  styleUrl: './oggetto-create.component.css'
})
export class OggettoCreateComponent {

  
  codice: string | undefined;
  nome: string | undefined;
  descrizione: string | undefined;

  constructor(private service: OggettoService){

  }

  salvaProdotto(){
    
    let ogg = new Oggetto(this.codice, this.nome, this.descrizione);
    this.service.inserisciOggetto(ogg);
    console.log("diocane");
    
  }

}
