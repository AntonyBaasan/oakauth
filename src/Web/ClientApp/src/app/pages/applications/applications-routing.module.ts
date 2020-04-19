import { NgModule } from '@angular/core';
import { ApplicationsComponent } from './applications.component';
import { Routes, RouterModule } from '@angular/router';
import { ApplicationsDetailsComponent } from './applications-details/applications-details.component';

const routes: Routes = [
  {
    path: '',
    component: ApplicationsComponent,
  },
  {
    path: '/detail/:id',
    component: ApplicationsDetailsComponent,
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ApplicationsRoutingModule { }
