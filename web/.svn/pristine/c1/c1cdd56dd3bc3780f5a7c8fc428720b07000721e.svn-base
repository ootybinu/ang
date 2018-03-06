import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
//import { SharedModule}  from '../shared/shared.module';
import { HttpClientService } from '../shared/http-client.service';
import { RealtimeService } from '../shared/realtime.service';
import { CommonService} from '../shared/common.service';
import { RealtimeComponent } from './realtime.component';
import { ToolsModule } from  '../common/tools/tools.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RealtimeSearchComponent } from './realtime-search/realtime-search.component';
// import {GoogleChart} from '../../../../node_modules/angular2-google-chart/directives/angular2-google-chart.directive';
import { RealtimeHistoryComponent } from './realtime-history/realtime-history.component';
import { RejectedmessageComponent } from './rejectedmessage/rejectedmessage.component';

const routes:Routes=[{path:'', component:RealtimeComponent}, 
 {path:'history/:id', component:RealtimeHistoryComponent},
 {path:'rejected', component:RejectedmessageComponent}

 ];
@NgModule({
  imports: [
    CommonModule, 
    ToolsModule,
    RouterModule.forChild(routes), 
    FormsModule,
    NgbModule
  ],
    providers: [HttpClientService, RealtimeService,CommonService],
  	declarations: [ RealtimeComponent,RealtimeSearchComponent,  RealtimeHistoryComponent, RejectedmessageComponent ], 
  	entryComponents:[RealtimeSearchComponent]
})
export class RealtimeModule { }
