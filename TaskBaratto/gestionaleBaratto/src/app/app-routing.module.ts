import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OggettoCreateComponent } from './components/oggetto-create/oggetto-create.component';
import { OggettoListComponent } from './components/oggetto-list/oggetto-list.component';

const routes: Routes = [
  {path: "", redirectTo: "oggetto/lista", pathMatch: "full"},
  {path: "oggetto/lista", component: OggettoListComponent},
  {path: "oggetto/inserisci", component: OggettoCreateComponent}
  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
