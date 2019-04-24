import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FolderAddButtonComponent } from './folder-add-button.component';

describe('FolderAddButtonComponent', () => {
  let component: FolderAddButtonComponent;
  let fixture: ComponentFixture<FolderAddButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FolderAddButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FolderAddButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
