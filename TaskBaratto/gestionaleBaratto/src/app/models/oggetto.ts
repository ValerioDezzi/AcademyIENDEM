export class Oggetto {
    codice: string|undefined;
    nome:string|undefined;
    descrizione: string|undefined;

    constructor(codice?: string, nome?: string, descrizione?: string){
        this.codice = codice;
        this.nome = nome;
        this.descrizione = descrizione;
        
    }


}
