import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationsListComponent } from './applications-list.component';
import { IconsModule } from 'src/app/shared/icons/icons.module';

describe('ApplicationsListComponent', () => {
  let component: ApplicationsListComponent;
  let fixture: ComponentFixture<ApplicationsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplicationsListComponent],
      imports: [IconsModule],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
