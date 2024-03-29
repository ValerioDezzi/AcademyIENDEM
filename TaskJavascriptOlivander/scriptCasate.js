//stampa casate
const stampaCasate = () => {
    let elencoCasate = JSON.parse(localStorage.getItem('casate'));

    let stringaTabellaCasate='';
    for(let[idx,item] of elencoCasate.entries()){
        stringaTabellaCasate+=`
        <tr>
            <td>${idx+1}</td>
            <td>${item.nome}</td>
            <td>${item.descrizione}</td>
            <td>${item.logo}</td>
            <td>${item.numero}</td>
          
            <td class="text-right">
                <button class="btn btn-warning" onclick="modificaCasata(${idx})">
                <i class="fa-solid fa-pencil"></i>
                </button>
                <button class="btn btn-outline-danger" data-toggle="modal"  onclick="eliminaCasata(${idx})">
                    <i class="fa-solid fa-trash"></i>
                </button>  
            </td>
        </tr>
        `;
    }
    document.getElementById("corpo-tabellaCasate").innerHTML=stringaTabellaCasate;
}

//aggiungicasata
const aggiungiCasata = () => {
    let nome = document.getElementById("inputNome").value
    let descrizione = document.getElementById("inputDescrizione").value
    let logo = document.getElementById("inputLogo").value
    let numero = document.getElementById("inputNumero").value
   
    let cas={
        nome,
        descrizione,
        logo,
        numero
    }
    let elencoCasate=JSON.parse(localStorage.getItem('casate'));
    elencoCasate.push(cas);
    localStorage.setItem('casate',JSON.stringify(elencoCasate));

    document.getElementById("inputNome").value="";
    document.getElementById("inputDescrizione").value="";
    document.getElementById("inputLogo").value="";
    document.getElementById("inputNumero").value="";


    stampaCasate();
    $("modaleInsCasata").modal("hide");
}

//eliminacasata
const eliminaCasata = (indice) => {
    let elencoCasate = JSON.parse( localStorage.getItem('casate') );
    elencoCasate.splice(indice, 1);
    localStorage.setItem('casate', JSON.stringify(elencoCasate));

    stampaCasate();
}
//modifica casata(apertura modale)
const modificaCasata = (indice) => {

    let elencoCasate = JSON.parse( localStorage.getItem('casate') );

    document.getElementById("update-nome").value = elencoCasate[indice].nome;
    document.getElementById("update-descrizione").value = elencoCasate[indice].descrizione;
    document.getElementById("update-logo").value = elencoCasate[indice].logo;
    document.getElementById("update-numero").value = elencoCasate[indice].numero;

    $("#modaleModificaCasata").data("identificativo", indice);

    $("#modaleModificaCasata").modal("show");
}

//update casate(cambiovalori)
const updateCasata = () => {
    let nome = document.getElementById("update-nome").value;
    let descrizione = document.getElementById("update-descrizione").value;
    let logo = document.getElementById("update-logo").value;
    let numero = document.getElementById("update-numero").value;

    let cas = {
        nome,
        descrizione,
        logo,
        numero
    }

    let indice = $("#modaleModificaCasata").data("identificativo")

    let elencoCasate = JSON.parse( localStorage.getItem('casate') );
    elencoCasate[indice] = cas;
    localStorage.setItem('casate', JSON.stringify(elencoCasate));

    $("#modaleModificaCasata").modal("hide");
}

// creazione elenco casate
let elencoCasateString= localStorage.getItem('casate');
if(!elencoCasateString)
    localStorage.setItem('casate',JSON.stringify([]));

setInterval(() => {
     stampaCasate(); 
}, 3000);

stampaCasate(); 