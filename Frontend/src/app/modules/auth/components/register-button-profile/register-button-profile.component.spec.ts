import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterButtonProfileComponent } from './register-button-profile.component';

describe('RegisterButtonProfileComponent', () => {
  let component: RegisterButtonProfileComponent;
  let fixture: ComponentFixture<RegisterButtonProfileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterButtonProfileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterButtonProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
