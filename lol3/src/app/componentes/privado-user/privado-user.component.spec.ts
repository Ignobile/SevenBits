import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrivadoUserComponent } from './privado-user.component';

describe('PrivadoUserComponent', () => {
  let component: PrivadoUserComponent;
  let fixture: ComponentFixture<PrivadoUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrivadoUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrivadoUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
