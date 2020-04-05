import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FetchDataComponent } from './fetch-data.component';
import { FetchDataRoutingModule } from './fetch-data-routing.module';

@NgModule({
  imports: [CommonModule, FetchDataRoutingModule],
  declarations: [FetchDataComponent],
})
export class FetchDataModule {}
