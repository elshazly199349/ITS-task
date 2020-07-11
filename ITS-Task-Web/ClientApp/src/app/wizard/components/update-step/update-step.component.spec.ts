import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateStepComponent } from './update-step.component';

describe('UpdateStepComponent', () => {
  let component: UpdateStepComponent;
  let fixture: ComponentFixture<UpdateStepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateStepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateStepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
