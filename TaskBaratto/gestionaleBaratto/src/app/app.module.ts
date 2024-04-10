import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OggettoCreateComponent } from './components/oggetto-create/oggetto-create.component';
import { FormsModule } from '@angular/forms';
import { OggettoListComponent } from './components/oggetto-list/oggetto-list.component';

@NgModule({
  declarations: [
    AppComponent,
    OggettoCreateComponent,
    OggettoListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
