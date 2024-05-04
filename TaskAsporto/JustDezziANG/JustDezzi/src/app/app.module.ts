import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RistorantiListaComponent } from './components/ristoranti-lista/ristoranti-lista.component';
import { RouterLink, RouterOutlet } from '@angular/router';
import { UtenteDettaglioComponent } from './components/utente-dettaglio/utente-dettaglio.component';

@NgModule({
  declarations: [
    AppComponent,
    RistorantiListaComponent,
    UtenteDettaglioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterOutlet,
    RouterLink
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
