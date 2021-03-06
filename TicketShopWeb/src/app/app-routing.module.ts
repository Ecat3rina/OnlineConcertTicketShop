import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { SearchEventsComponent } from './components/search-events/search-events.component';
import { WishlistComponent } from './components/wishlist/wishlist.component';
import { ProfileComponent } from './components/profile/profile.component';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(x => x.AdminModule)
  },
  {
    path: 'home',
    component: HomeComponent,
    children: [
      {
        path: '',
        redirectTo: 'events',
        pathMatch: 'full'
      },
      {
        path: 'events',
        component: SearchEventsComponent
      },
      {
        path: 'favorites',
        component: WishlistComponent
      },
      {
        path: 'search',
        component: SearchEventsComponent
      },
      {
        path: 'profile',
        component: ProfileComponent
      }
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
