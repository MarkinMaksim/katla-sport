import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountantFormComponent } from './accountant-form.component';

describe('HiveFormComponent', () => {
  let component: AccountantFormComponent;
  let fixture: ComponentFixture<AccountantFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountantFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountantFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
