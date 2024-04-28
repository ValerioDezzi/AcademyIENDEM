import { Component } from '@angular/core';
import { Prodotto } from '../../models/prodotto';
import { ProdottoService } from '../../sevices/prodotto.service';

@Component({
  selector: 'app-prodotto-lista',
  templateUrl: './prodotto-lista.component.html',
  styleUrl: './prodotto-lista.component.css'
})
export class ProdottoListaComponent {

  elenco:Prodotto[]=new Array();
  handleInterval: any;

  private cod:	string | undefined;
  nom:	string | undefined;
  cat:	string | undefined;
  des:	string | undefined;
  pre:	number | undefined;
  qua:	number | undefined;
  constructor(private service: ProdottoService){}

  stampa():void{
    this.service.recuperaTuttiNonFiltrati().subscribe(risultato =>{
      this.elenco=<Prodotto[]>risultato.data;
    })
  }
  ngOnInit(): void {
    this.handleInterval=setInterval(()=>{
      this.stampa();
    },1000)
  }
}
