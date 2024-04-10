import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OggettoListComponent } from './oggetto-list.component';

describe('OggettoListComponent', () => {
  let component: OggettoListComponent;
  let fixture: ComponentFixture<OggettoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OggettoListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OggettoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
