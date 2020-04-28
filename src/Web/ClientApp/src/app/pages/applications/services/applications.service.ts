import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Application } from '../models/Application';

@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  private backendUrl = '/api/applications';

  constructor(private http: HttpClient) { }

  getApplications(): Observable<Array<Application>> {
    return this.http.get<Array<Application>>(this.backendUrl);
  }

  getApplication(clientId: string): Observable<Application> {
    return this.http.get<Application>(this.backendUrl + '/' + clientId);
  }
}
