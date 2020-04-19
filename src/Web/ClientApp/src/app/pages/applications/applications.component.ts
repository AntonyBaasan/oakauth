import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from './models/Application';
import { ApplicationsService } from './services/applications.service';

@Component({
  selector: 'app-applications-component',
  templateUrl: './applications.component.html',
})
export class ApplicationsComponent {
  applications$: Observable<Array<Application>>;

  constructor(private applicationsService: ApplicationsService) {
    this.applications$ = applicationsService.getApplications();
  }
}
