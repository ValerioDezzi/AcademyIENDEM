import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OggettoCreateComponent } from './oggetto-create.component';

describe('OggettoCreateComponent', () => {
  let component: OggettoCreateComponent;
  let fixture: ComponentFixture<OggettoCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OggettoCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OggettoCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
