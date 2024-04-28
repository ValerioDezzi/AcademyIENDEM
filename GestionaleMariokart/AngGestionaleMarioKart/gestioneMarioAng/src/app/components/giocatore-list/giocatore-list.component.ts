import { Component } from '@angular/core';
import { Giocatore } from '../../models/giocatore';
import { GiocatoreService } from '../../services/giocatore.service';

@Component({
  selector: 'app-giocatore-list',
  templateUrl: './giocatore-list.component.html',
  styleUrl: './giocatore-list.component.css'
})
export class GiocatoreListComponent {

  elenco: Giocatore[]=new Array();
  nom: string|undefined;

  constructor(private service:GiocatoreService){}

  stampa():void{
    this.service.recuperaTutti().subscribe(risultato=>{
      this.elenco=<Giocatore[]>risultato.data;
    })
  }
  ngOnInit():void{
    this.stampa();
  }

}
