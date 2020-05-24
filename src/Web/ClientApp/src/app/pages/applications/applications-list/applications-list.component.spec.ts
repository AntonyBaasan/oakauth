import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationsListComponent } from './applications-list.component';
import { IconsModule } from 'src/app/shared/icons/icons.module';
import { ApplicationsService } from '../services/applications.service';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { of } from 'rxjs';

describe('ApplicationsListComponent', () => {
  let component: ApplicationsListComponent;
  let fixture: ComponentFixture<ApplicationsListComponent>;
  const routerSpy = jasmine.createSpyObj('Router', ['navigate']);
  const applicationsServiceStub = {
    getAll() { return of([]); }
  };
  const activatedRouteSpy = jasmine.createSpyObj('ActivatedRoute', ['']);

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplicationsListComponent],
      imports: [IconsModule, RouterModule],
      providers: [
        { provide: ApplicationsService, useValue: applicationsServiceStub },
        { provide: Router, useValue: routerSpy },
        { provide: ActivatedRoute, useValue: activatedRouteSpy },
      ]
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
