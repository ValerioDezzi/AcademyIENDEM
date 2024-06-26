import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiocatoreListComponent } from './giocatore-list.component';

describe('GiocatoreListComponent', () => {
  let component: GiocatoreListComponent;
  let fixture: ComponentFixture<GiocatoreListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GiocatoreListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GiocatoreListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
