import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PathLineComponent } from './path-line.component';

describe('PathLineComponent', () => {
  let component: PathLineComponent;
  let fixture: ComponentFixture<PathLineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PathLineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PathLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
