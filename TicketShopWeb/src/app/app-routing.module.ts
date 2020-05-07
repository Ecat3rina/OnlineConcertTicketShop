import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SearchEventsComponent } from './components/search-events/search-events.component';


const routes: Routes = [
  {
    path: '',
    pathMatch : 'full',
    redirectTo : 'home'
  },
  {
    path: 'login',
    component : LoginComponent
  },
  {
    path : 'home',
    component : HomeComponent,
    children : [
      {
        path : '',
        redirectTo : 'events',
        pathMatch : 'full'
      },
      {
        path : 'events',
        component : SearchEventsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
