import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ApplicationsComponent } from './applications.component';
import { CommonModule } from '@angular/common';
import { ApplicationsRoutingModule } from './applications-routing.module';
import { ApplicationsListComponent } from './applications-list/applications-list.component';
import { IconsModule } from 'src/app/shared/icons/icons.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { ApplicationAddComponent } from './application-add/application-add.component';
import { ApplicationSettingsComponent } from './application-settings/application-settings.component';
import { ToastsComponent } from 'src/app/shared/toast/toasts.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ApplicationsRoutingModule,
    IconsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  declarations: [
    ApplicationsComponent,
    ApplicationsListComponent,
    ApplicationAddComponent,
    ApplicationSettingsComponent,
    ToastsComponent
  ],
})
export class ApplicationsModule {}
