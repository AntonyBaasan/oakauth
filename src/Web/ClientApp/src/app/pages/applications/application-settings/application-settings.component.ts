import { Component, OnInit } from '@angular/core';
import { ApplicationsService } from '../services/applications.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { Application } from '../models/Application';

@Component({
  selector: 'app-application-settings',
  templateUrl: './application-settings.component.html',
  styleUrls: ['./application-settings.component.css'],
})
export class ApplicationSettingsComponent implements OnInit {
  applicationDebug$: Observable<Application>;
  applicationForm: FormGroup;

  constructor(
    applicationsService: ApplicationsService,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    const clientId = route.snapshot.paramMap.get('clientId');
    this.applicationDebug$ = applicationsService.getApplication(clientId);
    applicationsService.getApplication(clientId).subscribe((application) => {
      this.applicationForm = this.fb.group({
        clientId: [application.clientId],
        clientName: [application.clientName],
        description: [application.clientDescription],
        clientSecret: [''],
        applicationType: [application.applicationType],
        allowedScopes: [application.allowedScopes],
        properties: [application.properties],
      });
    });
  }

  ngOnInit() {}
}
