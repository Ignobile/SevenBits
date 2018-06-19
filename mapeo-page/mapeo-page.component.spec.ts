import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MapeoPageComponent } from './mapeo-page.component';

describe('MapeoPageComponent', () => {
  let component: MapeoPageComponent;
  let fixture: ComponentFixture<MapeoPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapeoPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MapeoPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
