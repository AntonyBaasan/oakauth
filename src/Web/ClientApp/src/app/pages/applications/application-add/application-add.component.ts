import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ApplicationType } from '../models/ApplicationType';
import { Router, ActivatedRoute } from '@angular/router';

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

  constructor(private router: Router, private route: ActivatedRoute) {}

  get applicationTypeEnum() { return ApplicationType; }
  get f() { return this.applicationForm.controls; }

  ngOnInit() {}

  create() {}

  cancel() {
    this.router.navigate(['applications']);
  }

  selectApplicationType(type: ApplicationType) {
    this.applicationType = type;
  }
}
