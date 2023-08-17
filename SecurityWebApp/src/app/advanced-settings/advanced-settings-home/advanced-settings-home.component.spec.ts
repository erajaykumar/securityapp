import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvancedSettingsHomeComponent } from './advanced-settings-home.component';

describe('AdvancedSettingsHomeComponent', () => {
  let component: AdvancedSettingsHomeComponent;
  let fixture: ComponentFixture<AdvancedSettingsHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdvancedSettingsHomeComponent]
    });
    fixture = TestBed.createComponent(AdvancedSettingsHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
