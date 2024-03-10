# Edicola
Lo scopo di questa app è gestire l inventario e le vendite di un edicola.
## Classi
1.  *Program*:  Classe Controller che si occupa di avviare il main e inoltre
   - Istanziare oggetti Pubblicazione
   - Istanziare oggetto Edicola
 
2.  *Pubblicazione*:  classe astratta madre di Giornale e Rivista,contiene i membri e i metodi in comune con le sue sottoclassi
   
3.  *Giornale*: classe per istanziare oggetti Giornale che eredita Pubblicazione,ne condivide gli attributi e ha l override del medoso stampaDettagli()
  
4. *Rivista*: classe per istanziare oggetti Rivista che eredita Pubblicazione,ne condivide gli attributi e ha l override del medoso stampaDettagli()
 
5. *Edicola*: classe Service con il suo nome e una lista inventatio.I suoi metodi:
 
   - aggiungiPubblicazione():Aggiunge una pubblicazione al suo interno,se ne è presente gia una aumenta il contatore dello stock.
   - stampaInventario() : Stampa i dettagli di tutte le pubblicazioni all interno dell inventario.
   - rimuoviPubblicazione() : Se la pubblicazione inserita è all interno dell inventario viene eliminata e il suo stock diminuisce di 1,sennnò messaggio di errore.
   - ricercaInventario(): tramite un codice input cerca una pubblicazione nell Inventario,se non cè messaggio di errore.
   - aggiornaStock(): aggiorna la quantita di stock di un oggetto dato da input e lo aggiorna nel numero dato in input,se la pubblicazione non ce messaggio di errore.
   - stampaDisponibiltaFiltrata(): stampa solo le pubblicazioni di cui si hanno copie nell inventario.
   - 
6. *EdicolaFinanza*: estensione di Edicola,gestisce le operazioni di vendita e ha una lista di elencoVendite:
   -vendiPubblicazione(): se la pubblicazione input è all interno ne rimuove uno dallo stock e salva le informazioni della vendita nell elencoVendite.
   -stampaElencoVendite():stampa i dettagli di tutte le vendite.
   -stampaVenditePerData():stampa le vendite avvenute nel giorno dataInput.
7. *Vendita*: classe che crea oggetti vendita, ogni volta che l edicola chiama il metodo vendiPubblicazione(),salva l 'oggetto venduto,il suo  valore e la data di vendita
  
