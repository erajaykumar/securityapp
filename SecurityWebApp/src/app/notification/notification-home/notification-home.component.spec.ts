import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotificationHomeComponent } from './notification-home.component';

describe('NotificationHomeComponent', () => {
  let component: NotificationHomeComponent;
  let fixture: ComponentFixture<NotificationHomeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NotificationHomeComponent]
    });
    fixture = TestBed.createComponent(NotificationHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
