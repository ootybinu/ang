import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientService} from './http-client.service';
import { RealtimeService} from './realtime.service';
import { UnitreportService } from './unitreport.service';
import { GprsdataService } from './gprsdata.service';
import { GuardService } from './guard.service';
import { AuthenticateService } from './authenticate.service';
import { MessengerService } from './messenger.service';
import { CommonService } from './common.service';
import { RevenueService } from './revenue.service';
import { UnitSummaryService } from './unitsummary.service';
import { UserService } from './user.service';
import { RoleService } from './role.service';
import { OrganizationService } from './organization.service';
import { OemService } from './oem.service';
import { TamperdetectionService } from './tamperdetection.service';
import { DashboardService } from './dashboard.service';
import { BillingService } from './billing.service';
import { TariffService } from './tariff.service';
@NgModule()
export class SharedModule {
	static forRoot(): ModuleWithProviders {
		return {
			ngModule:SharedModule, 
			providers : [ GuardService, MessengerService, AuthenticateService,HttpClientService,RealtimeService, 
							UnitreportService, GprsdataService ,CommonService, RevenueService, UnitSummaryService,
							UserService, RoleService, OrganizationService, OemService, 
							TamperdetectionService, DashboardService, BillingService, TariffService]
		};
	}
 }
