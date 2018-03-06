import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { AppComponent } from './app.component';
//import { LoginComponent } from './login/login.component';
import { SharedModule} from './modules/shared/shared.module';
import { routing } from './app.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PingComponent } from './ping/ping.component';
import { MissingComponent } from './missing/missing.component';
import { ToastModule} from 'ng2-toastr/ng2-toastr';
/*const  routes:Routes=[
{path:'home', loadChildren:'./modules/home/home.module#HomeModule'},
{path:'realtime', loadChildren:'./modules/realtime/realtime.module#RealtimeModule'},

];*/

@NgModule({
  declarations: [
    AppComponent,
    //LoginComponent,
    PingComponent,
    MissingComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule, 
    //RouterModule.forRoot(routes), 
    routing,BrowserAnimationsModule,
    ToastModule.forRoot(),
    SharedModule.forRoot(), 
    NgbModule.forRoot()
  ],
  providers: [SharedModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
