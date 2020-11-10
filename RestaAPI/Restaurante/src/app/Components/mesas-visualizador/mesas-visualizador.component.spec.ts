import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MesasVisualizadorComponent } from './mesas-visualizador.component';

describe('MesasVisualizadorComponent', () => {
  let component: MesasVisualizadorComponent;
  let fixture: ComponentFixture<MesasVisualizadorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MesasVisualizadorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MesasVisualizadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
