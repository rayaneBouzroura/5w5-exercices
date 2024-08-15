/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ApiTestComponent } from './api-test.component';

describe('ApiTestComponent', () => {
  let component: ApiTestComponent;
  let fixture: ComponentFixture<ApiTestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApiTestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApiTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
