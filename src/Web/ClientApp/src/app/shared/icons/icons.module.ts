import { NgModule } from '@angular/core';
import { FeatherModule } from 'angular-feather';
import { Globe, Hexagon, Layers } from 'angular-feather/icons';

const icons: any = {
  Globe,
  Hexagon,
  Layers,
};

@NgModule({
  imports: [
    FeatherModule.pick(icons)
  ],
  exports: [
    FeatherModule
  ]
})
export class IconsModule { }
