import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Application } from '../models/Application';
import { ApplicationType } from '../models/ApplicationType';

@Injectable({
  providedIn: 'root',
})
export class ApplicationsService {
  private backendUrl = '/api/applications';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<Application>> {
    return this.http.get<Array<Application>>(this.backendUrl);
  }

  getByClientId(clientId: string): Observable<Application> {
    return this.http.get<Application>(this.backendUrl + '/' + clientId);
  }

  create(name: string, applicationType: ApplicationType) {
    return this.http.post<Application>(this.backendUrl, {
      clientName: name,
      applicationType: applicationType,
    });
  }

  save() {
    return this.http.get<Application>(this.backendUrl);
  }
}
