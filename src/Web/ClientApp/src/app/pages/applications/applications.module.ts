import { NgModule } from '@angular/core';
import { ApplicationsComponent } from './applications.component';
import { CommonModule } from '@angular/common';
import { ApplicationsRoutingModule } from './applications-routing.module';
import { ApplicationsListComponent } from './applications-list/applications-list.component';
import { ApplicationsDetailsComponent } from './applications-details/applications-details.component';
import { IconsModule } from 'src/app/shared/icons/icons.module';

@NgModule({
  imports: [
    CommonModule,
    ApplicationsRoutingModule,
    IconsModule
  ],
  declarations: [
    ApplicationsComponent,
    ApplicationsDetailsComponent,
    ApplicationsListComponent,
  ],
})
export class ApplicationsModule {}
