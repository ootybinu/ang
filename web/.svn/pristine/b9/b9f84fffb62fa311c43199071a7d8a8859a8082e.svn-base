import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { CommonService} from '../shared/common.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
import { GprsdataService } from '../shared/gprsdata.service';
import { GprsdataComponent } from './gprsdata.component';
import { HistoryComponent } from './history/history.component';
import { DetailComponent } from './detail/detail.component';

const routes:Routes=[{path:'', component:GprsdataComponent}, {path:'history/:id', component:HistoryComponent}, {path:'detail/:id/:ondate', component:DetailComponent}];
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ToolsModule,
    RouterModule.forChild(routes)
  ],
  providers: [HttpClientService, GprsdataService,CommonService],
  declarations: [GprsdataComponent, HistoryComponent, DetailComponent]
})
export class GprsdataModule { }
