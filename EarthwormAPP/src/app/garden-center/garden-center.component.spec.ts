import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GardenCenterComponent } from './garden-center.component';

describe('GardenCenterComponent', () => {
  let component: GardenCenterComponent;
  let fixture: ComponentFixture<GardenCenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GardenCenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GardenCenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
