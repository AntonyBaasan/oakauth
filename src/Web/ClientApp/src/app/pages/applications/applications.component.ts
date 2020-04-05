import { Component } from '@angular/core';

@Component({
  selector: 'app-applications-component',
  templateUrl: './applications.component.html'
})
export class ApplicationsComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
