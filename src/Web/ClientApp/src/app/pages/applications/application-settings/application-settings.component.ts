import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { ApplicationsService } from '../services/applications.service';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { Application } from '../models/Application';
import { ApplicationType } from '../models/ApplicationType';
import { ToastsService } from 'src/app/shared/toast/toasts.service';

@Component({
  selector: 'app-application-settings',
  templateUrl: './application-settings.component.html',
  styleUrls: ['./application-settings.component.css'],
})
export class ApplicationSettingsComponent implements OnInit {
  applicationDebug$: Observable<Application>;
  applicationForm: FormGroup;
  application: Application;
  @ViewChild('successTemplate')
  private successTemplate: TemplateRef<any>;

  constructor(
    private applicationsService: ApplicationsService,
    route: ActivatedRoute,
    private fb: FormBuilder,
    private toastsService: ToastsService
  ) {
    const clientId = route.snapshot.paramMap.get('clientId');
    this.applicationDebug$ = applicationsService.getByClientId(clientId);
    applicationsService.getByClientId(clientId).subscribe((application) => {
      this.application = application;

      this.applicationForm = this.fb.group({
        clientId: [application.clientId],
        clientName: [application.clientName],
        description: [application.clientDescription],
        clientSecret: [application.properties['client_secret']],
        applicationType: [application.applicationType],
        allowedScopes: [application.allowedScopes],
        properties: [application.properties],
      });
    });
  }

  ngOnInit() {}

  getApplicationTypeText() {
    switch (this.application.applicationType) {
      case ApplicationType.Native:
        return 'Native';
      case ApplicationType.RegularWeb:
        return 'Regular Web';
      case ApplicationType.SinglePageApplication:
        return 'Single Page Application';
      case ApplicationType.MachineToMachine:
        return 'Machine To Machine';
    }
  }

  saveChanges() {
    this.applicationsService.save().subscribe((savedApplication) => {
      this.toastsService.show(this.successTemplate, {
        classname: 'bg-success text-light',
        delay: 100000,
      });
    });
  }
}
