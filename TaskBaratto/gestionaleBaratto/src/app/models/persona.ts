import { Oggetto } from "./oggetto";

export class Persona {
    nominativo: string | undefined;
    codice: string | undefined;
    oggettiScambiabili:Oggetto[]=new Array();
    

    constructor(nominativo?: string, codice?:string ){
        this.nominativo = nominativo;
        this.codice = codice;
       
    }
}
