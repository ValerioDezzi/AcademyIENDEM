import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RistorantiListaComponent } from './ristoranti-lista.component';

describe('RistorantiListaComponent', () => {
  let component: RistorantiListaComponent;
  let fixture: ComponentFixture<RistorantiListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RistorantiListaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RistorantiListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
