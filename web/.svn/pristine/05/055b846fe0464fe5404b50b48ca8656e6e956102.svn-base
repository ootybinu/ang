import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonService } from '../shared/common.service';
import { GuardService } from '../../modules/shared/guard.service';
import { BillingService } from '../shared/billing.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
import { GenbillComponent } from './genbill/genbill.component';
import { BillgroupComponent } from './billgroup/billgroup.component';
import { ViewbillComponent } from './viewbill/viewbill.component';
// import { BilldetailComponent } from '../common/tools/billdetail/billdetail.component';

const routes:Routes=[{path:'generate', canActivate:[GuardService],component:GenbillComponent}, 
 {path:'view', canActivate:[GuardService], component:ViewbillComponent},
 {path:'bg', canActivate:[GuardService],component:BillgroupComponent} ];

@NgModule({
  imports: [
    CommonModule,
     ToolsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [HttpClientService, CommonService,GuardService, BillingService],
  declarations: [GenbillComponent, ViewbillComponent,  BillgroupComponent]
})
export class BillingModule { }
