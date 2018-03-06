import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { TamperdetectionComponent } from './tamperdetection.component';
import { CommonService } from '../shared/common.service';
import { TamperdetectionService } from '../shared/tamperdetection.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
const routes:Routes=[{path:'', component:TamperdetectionComponent}];
@NgModule({
  imports: [
    CommonModule,
    ToolsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
   providers: [HttpClientService, CommonService,TamperdetectionService],
  declarations: [TamperdetectionComponent]
})
export class TamperdetectionModule { }
