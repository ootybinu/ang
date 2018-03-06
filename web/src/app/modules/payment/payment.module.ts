import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModuleWithProviders} from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonService } from '../shared/common.service';
import { GuardService } from '../../modules/shared/guard.service';
import { PaymentService } from '../shared/payment.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
import { PaymententryComponent } from './paymententry/paymententry.component';
// import { BilldetailComponent} from '../common/tools/billdetail/billdetail.component';
import { PaymentdetailComponent } from './paymentdetail/paymentdetail.component';
import { PaymentcancelComponent } from './paymentcancel/paymentcancel.component';
import { PaymentauthenticationComponent } from './paymentauthentication/paymentauthentication.component';
import { PaymentprocessComponent } from './paymentprocess/paymentprocess.component'

const routes:Routes=[{path:'entry', canActivate:[GuardService],component:PaymententryComponent},
					{path:'cancel', canActivate:[GuardService],component:PaymentcancelComponent}, 
					{path:'authenticate', canActivate:[GuardService],component:PaymentauthenticationComponent},
          {path:'process', canActivate:[GuardService],component:PaymentprocessComponent},
          ]

@NgModule({
  imports: [
    CommonModule,
    ToolsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [HttpClientService, CommonService,GuardService, PaymentService],
  declarations: [ PaymententryComponent, PaymentdetailComponent, PaymentcancelComponent, PaymentauthenticationComponent, PaymentprocessComponent]
})
export class PaymentModule { }
