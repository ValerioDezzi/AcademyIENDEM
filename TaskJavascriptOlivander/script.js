//stampa
const stampa = () => {
    let elenco = JSON.parse(localStorage.getItem('bacchette'));

    let stringaTabella='';
    for(let[idx,item] of elenco.entries()){
        stringaTabella+=`
        <tr>
            <td>${idx+1}</td>
            <td>${item.codice}</td>
            <td>${item.materiale}</td>
            <td>${item.nucleo}</td>
            <td>${item.lunghezza}</td>
            <td>${item.resistenza}</td>
            <td>${item.proprietario}</td>
            <td>${item.casata}</td>
            <td>${item.link}</td>
            <td class="text-right">
                <button class="btn btn-warning" onclick="modificaBacchetta(${idx})">
                <i class="fa-solid fa-pencil"></i>
                </button>
                <button class="btn btn-outline-danger" onclick="eliminaBacchetta(${idx})">
                    <i class="fa-solid fa-trash"></i>
                </button>  
            </td>
        </tr>
        `;
    }
    document.getElementById("corpo-tabella").innerHTML=stringaTabella;
}

//aggiungibacchetta
const aggiungiBacchetta = () => {
    let codice = document.getElementById("inputCodice").value;
    let materiale = document.getElementById("inputMateriale").value;
    let nucleo = document.getElementById("inputNucleo").value;
    let lunghezza = document.getElementById("inputLunghezza").value;
    let resistenza = document.getElementById("inputResistenza").value;
    let proprietario = document.getElementById("inputProprietario").value;
    let casata = document.getElementById("inputCasata").value;
    let link = document.getElementById("inputLink").value;

    let bacc={
        codice,
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        proprietario,
        casata,
        link
    }
    let elenco=JSON.parse(localStorage.getItem('bacchette'));
    elenco.push(bacc);
    localStorage.setItem('bacchette',JSON.stringify(elenco));

    document.getElementById("inputCodice").value="";
    document.getElementById("inputMateriale").value="";
    document.getElementById("inputNucleo").value="";
    document.getElementById("inputLunghezza").value="";
    document.getElementById("inputResistenza").value="";
    document.getElementById("inputProprietario").value="";
    document.getElementById("inputCasata").value="";
    document.getElementById("inputLink").value="";

    stampa();
    $("modaleInsBacchetta").modal("hide");
}

//elimina bacchetta
const eliminaBacchetta =(indice)=>{
    let elenco = JSON.parse(localStorage.getItem('bacchette'));
    elenco.splice(indice,1);
    localStorage.setItem('bacchette',JSON.stringify(elenco));

    stampa();
}
const modificaBacchetta=(indice)=>{

    let elenco=JSON.parse(localStorage.getItem('bacchette'));
    document.getElementById("updateCodice").value=elenco[indice].codice;
    document.getElementById("updateMateriale").value=elenco[indice].materiale;
    document.getElementById("updateNucleo").value=elenco[indice].nucleo;
    document.getElementById("updateLunghezza").value=elenco[indice].lunghezza;
    document.getElementById("updateResistenza").value=elenco[indice].resistenza;
    document.getElementById("updateProprietario").value=elenco[indice].proprietario;
    document.getElementById("updateCasata").value=elenco[indice].casata;
    document.getElementById("updateLink").value=elenco[indice].link;
    $("#modaleModificaBacchetta").data("identificativo",indice)
    $("#modaleModificaBacchetta").modal("show");

}

const updateBacchetta=()=>{
    let codice = document.getElementById("updateCodice").value;
    let materiale = document.getElementById("updateMateriale").value;
    let nucleo = document.getElementById("updateNucleo").value;
    let lunghezza = document.getElementById("updateLunghezza").value;
    let resistenza = document.getElementById("updateResistenza").value;
    let proprietario = document.getElementById("updateProprietario").value;
    let casata = document.getElementById("updateCasata").value;
    let link = document.getElementById("updateLink").value;

    let bacc={
        codice,
        materiale,
        nucleo,
        lunghezza,
        resistenza,
        proprietario,
        casata,
        link
    }
    let indice = $('#modaleModificaBacchetta').data("identificativo")
    let elenco =JSON.parse(localStorage.getItem('bacchette'));
    elenco[indice]=bacc;
    localStorage.setItem('bacchette',JSON.stringify(elenco));
    $("#modaleModifica").modal("hide");

}

// creazione elenco bacchette
let elencoBacchetteString= localStorage.getItem('bacchette');
if(!elencoBacchetteString)
    localStorage.setItem('bacchette',JSON.stringify([]));

setInterval(() => {
     stampa(); 
}, 1000);

stampa(); 

   