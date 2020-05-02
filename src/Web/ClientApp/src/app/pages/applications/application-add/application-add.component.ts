import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApplicationType } from '../models/ApplicationType';
import { Router, ActivatedRoute } from '@angular/router';
import { ApplicationsService } from '../services/applications.service';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-application-add',
  templateUrl: './application-add.component.html',
  styleUrls: ['./application-add.component.css'],
})
export class ApplicationAddComponent implements OnInit {
  applicationForm = new FormGroup({
    applicationName: new FormControl('', Validators.required),
  });
  applicationType: ApplicationType = ApplicationType.Native;

  constructor(
    private applicationsService: ApplicationsService,
    private router: Router
  ) {}

  get applicationTypeEnum() {
    return ApplicationType;
  }
  get f() {
    return this.applicationForm.controls;
  }

  ngOnInit() {}

  create() {
    const name = this.applicationForm.value.applicationName;
    this.applicationsService
      .createApplication(name, this.applicationType)
      .pipe(
        finalize(() => {
          this.router.navigate(['applications']);
        })
      )
      .subscribe((result) => {});
  }

  cancel() {
    this.router.navigate(['applications']);
  }

  selectApplicationType(type: ApplicationType) {
    this.applicationType = type;
  }
}
