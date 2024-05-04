import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RistorantiListaComponent } from './components/ristoranti-lista/ristoranti-lista.component';
import { UtenteDettaglioComponent } from './components/utente-dettaglio/utente-dettaglio.component';

const routes: Routes = [
  {path: "", redirectTo:"ristoranti-lista", pathMatch:"full"},
  {path: "ristoranti-lista",component:RistorantiListaComponent},
  {path:"utente",component: UtenteDettaglioComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
