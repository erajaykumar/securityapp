import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsightDashboardComponent } from './insight-dashboard.component';

describe('InsightDashboardComponent', () => {
  let component: InsightDashboardComponent;
  let fixture: ComponentFixture<InsightDashboardComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InsightDashboardComponent]
    });
    fixture = TestBed.createComponent(InsightDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
