import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

const appRoutes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./pages/home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'counter',
    loadChildren: () =>
      import('./pages/counter/counter.module').then((m) => m.CounterModule),
  },
  {
    path: 'fetch-data',
    loadChildren: () =>
      import('./pages/fetch-data/fetch-data.module').then(
        (m) => m.FetchDataModule
      ),
  },
  {
    path: 'applications',
    loadChildren: () =>
      import('./pages/applications/applications.module').then(
        (m) => m.ApplicationsModule
      ),
  },
  {
    path: 'apis',
    loadChildren: () =>
      import('./pages/apis/apis.module').then(
        (m) => m.ApisModule
      ),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
