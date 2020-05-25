import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AdminRoutingModule } from './admin-routing.module';
import { MainComponent } from './components/main/main.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [
        MainComponent
    ],
    imports: [
        SharedModule,
        AdminRoutingModule
    ],

})
export class AdminModule { }
