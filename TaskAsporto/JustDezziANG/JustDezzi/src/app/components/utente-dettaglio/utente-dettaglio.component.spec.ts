import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UtenteDettaglioComponent } from './utente-dettaglio.component';

describe('UtenteDettaglioComponent', () => {
  let component: UtenteDettaglioComponent;
  let fixture: ComponentFixture<UtenteDettaglioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UtenteDettaglioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UtenteDettaglioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
