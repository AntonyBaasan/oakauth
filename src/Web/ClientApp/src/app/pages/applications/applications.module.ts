import { NgModule } from '@angular/core';
import { ApplicationsComponent } from './applications.component';
import { CommonModule } from '@angular/common';
import { ApplicationsRoutingModule } from './applications-routing.module';
import { ApplicationsListComponent } from './applications-list/applications-list.component';
import { ApplicationsDetailsComponent } from './applications-details/applications-details.component';

@NgModule({
  imports: [CommonModule, ApplicationsRoutingModule],
  declarations: [
    ApplicationsComponent,
    ApplicationsDetailsComponent,
    ApplicationsListComponent,
  ],
})
export class ApplicationsModule {}
