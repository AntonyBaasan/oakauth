import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApisRoutingModule } from './apis-routing.module';
import { ApisComponent } from './apis.component';

@NgModule({
  imports: [
    CommonModule, ApisRoutingModule
  ],
  declarations: [ApisComponent]
})
export class ApisModule { }
