import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistingRuleComponent } from './existing-rule.component';

describe('ExistingRuleComponent', () => {
  let component: ExistingRuleComponent;
  let fixture: ComponentFixture<ExistingRuleComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExistingRuleComponent]
    });
    fixture = TestBed.createComponent(ExistingRuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
