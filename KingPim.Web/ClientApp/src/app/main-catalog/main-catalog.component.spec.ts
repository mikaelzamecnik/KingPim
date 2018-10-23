import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCatalogComponent } from './main-catalog.component';

describe('MainCatalogComponent', () => {
  let component: MainCatalogComponent;
  let fixture: ComponentFixture<MainCatalogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MainCatalogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MainCatalogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
