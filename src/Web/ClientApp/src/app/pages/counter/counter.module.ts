import { NgModule } from '@angular/core';
import { CounterComponent } from './counter.component';
import { CommonModule } from '@angular/common';
import { CounterRoutingModule } from './counter-routing.module';

@NgModule({
  imports: [CommonModule, CounterRoutingModule],
  declarations: [CounterComponent]
})
export class CounterModule { }
