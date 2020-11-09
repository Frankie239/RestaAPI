import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoEditorComponent } from './producto-editor.component';

describe('ProductoEditorComponent', () => {
  let component: ProductoEditorComponent;
  let fixture: ComponentFixture<ProductoEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductoEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
