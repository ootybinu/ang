import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonService } from '../shared/common.service';
import { RevenueService } from '../shared/revenue.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
import { DashboardComponent } from './dashboard.component';

const routes:Routes=[{path:'', component:DashboardComponent}];
@NgModule({
  imports: [
    CommonModule, 
    ToolsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
   providers: [HttpClientService, CommonService],
  declarations: [DashboardComponent]
})
export class DashboardModule { }
