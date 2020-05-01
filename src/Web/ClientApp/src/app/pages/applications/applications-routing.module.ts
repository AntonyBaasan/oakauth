import { NgModule } from '@angular/core';
import { ApplicationsComponent } from './applications.component';
import { Routes, RouterModule } from '@angular/router';
import { ApplicationAddComponent } from './application-add/application-add.component';
import { ApplicationsListComponent } from './applications-list/applications-list.component';
import { ApplicationSettingsComponent } from './application-settings/application-settings.component';

const routes: Routes = [
  {
    path: '',
    component: ApplicationsComponent,
    children: [
      {
        path: '',
        component: ApplicationsListComponent,
      },
      {
        path: 'new',
        component: ApplicationAddComponent,
      },
      {
        path: 'settings/:id',
        component: ApplicationSettingsComponent,
      },
    ]
  }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ApplicationsRoutingModule { }
