class Persona{
    nominativo: string | undefined;
    codice: string | undefined;
    constructor(nominativo?: string, codice?: string){
        this.nominativo = nominativo;
        this.codice = codice;
    }
    
}


function aggiungiUtente(){



    const nominativoInput= document.getElementById('input-nominativo') as HTMLInputElement;
    const codiceInput = document.getElementById('input-codice')as HTMLInputElement;
    const nominativo = nominativoInput.value;
    const codice = codiceInput.value;

    const persona= new Persona(nominativo,codice);
    const elencoUtenti = JSON.parse(localStorage.getItem('elenco_utenti'));
    
    

    

   
} 


let elencoUtenti= localStorage.getItem("elenco_utenti");
if(!elencoUtenti)
    localStorage.setItem("elenco_utenti",JSON.stringify([])) //creo array in local storage vuoto

