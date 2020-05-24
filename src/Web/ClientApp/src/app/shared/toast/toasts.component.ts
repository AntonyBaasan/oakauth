import { Component, TemplateRef } from '@angular/core';
import { ToastsService } from './toasts.service';

@Component({
  selector: 'app-toasts',
  templateUrl: './toasts.component.html',
  styles: ['./toasts.component.css'],
  // tslint:disable-next-line: no-host-metadata-property
  host: {'[class.ngb-toasts]': 'true'}
})
export class ToastsComponent {
  constructor(public toastsService: ToastsService) {}

  isTemplate(toast) { return toast.textOrTpl instanceof TemplateRef; }
}
