import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PathLineItemComponent } from './path-line-item.component';

describe('PathLineItemComponent', () => {
  let component: PathLineItemComponent;
  let fixture: ComponentFixture<PathLineItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PathLineItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PathLineItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
