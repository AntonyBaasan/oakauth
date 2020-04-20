import { NgModule } from '@angular/core';
import { FeatherModule } from 'angular-feather';
import { Globe, Hexagon, Layers, Settings, Book } from 'angular-feather/icons';

const icons: any = {
  Globe,
  Hexagon,
  Layers,
  Settings,
  Book,
};

@NgModule({
  imports: [FeatherModule.pick(icons)],
  exports: [FeatherModule],
})
export class IconsModule {}
