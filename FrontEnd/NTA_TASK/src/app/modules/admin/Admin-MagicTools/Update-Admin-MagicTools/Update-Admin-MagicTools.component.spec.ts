/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UpdateAdminMagicToolsComponent } from './Update-Admin-MagicTools.component';

describe('UpdateAdminMagicToolsComponent', () => {
  let component: UpdateAdminMagicToolsComponent;
  let fixture: ComponentFixture<UpdateAdminMagicToolsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateAdminMagicToolsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateAdminMagicToolsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
