import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { XoxMainComponent } from './xox-main.component';

describe('XoxMainComponent', () => {
  let component: XoxMainComponent;
  let fixture: ComponentFixture<XoxMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ XoxMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(XoxMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
