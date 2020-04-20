import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Application } from './models/Application';
import { ApplicationsService } from './services/applications.service';

@Component({
  selector: 'app-applications-component',
  templateUrl: './applications.component.html',
})
export class ApplicationsComponent implements OnInit {
  applications$: Observable<Array<Application>>;

  constructor(applicationsService: ApplicationsService) {
    this.applications$ = applicationsService.getApplications();
  }
  ngOnInit(): void {}
}
