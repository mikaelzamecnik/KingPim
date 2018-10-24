import { TestBed, inject } from '@angular/core/testing';

import { SubCategoryDataService } from './sub-category-data.service';

describe('SubCategoryDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SubCategoryDataService]
    });
  });

  it('should be created', inject([SubCategoryDataService], (service: SubCategoryDataService) => {
    expect(service).toBeTruthy();
  }));
});
