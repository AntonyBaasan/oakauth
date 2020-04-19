import { Component, OnInit, Input } from '@angular/core';
import { Application } from '../models/Application';

@Component({
  selector: 'app-applications-list',
  templateUrl: './applications-list.component.html',
  styleUrls: ['./applications-list.component.css'],
})
export class ApplicationsListComponent implements OnInit {
  @Input() items: Array<Application> = [];

  constructor() {}

  ngOnInit() {}
}
