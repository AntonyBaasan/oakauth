import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Application } from '../models/Application';

@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  constructor() {}

  getApplications(): Observable<Array<Application>> {
    return of([
      { id: '1dsaf1231', name: 'Test1' },
      { id: '2xcfdsfad', name: 'Test2' },
    ]);
  }
}
