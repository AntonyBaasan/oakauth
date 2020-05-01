import { Component, OnInit } from '@angular/core';
import { Application } from '../models/Application';
import { Observable } from 'rxjs';
import { ApplicationsService } from '../services/applications.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-applications-list',
  templateUrl: './applications-list.component.html',
  styleUrls: ['./applications-list.component.css'],
})
export class ApplicationsListComponent implements OnInit {

  applications$: Observable<Array<Application>>;

  constructor(applicationsService: ApplicationsService, private router: Router, private route: ActivatedRoute) {
    this.applications$ = applicationsService.getApplications();
  }

  ngOnInit() { }
}
