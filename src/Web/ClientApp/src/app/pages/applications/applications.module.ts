import { NgModule } from '@angular/core';
import { ApplicationsComponent } from './applications.component';
import { CommonModule } from '@angular/common';
import { ApplicationsRoutingModule } from './applications-routing.module';

@NgModule({
  imports: [CommonModule, ApplicationsRoutingModule],
  declarations: [ApplicationsComponent]
})
export class ApplicationsModule { }
