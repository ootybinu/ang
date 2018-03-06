import { ModuleWithProviders} from '@angular/core';
import { Routes, RouterModule} from '@angular/router';
import { GuardService } from './modules/shared/guard.service';
//import { CommonService } from './modules/shared/common.service';
import { PingComponent } from './ping/ping.component';
import { MissingComponent } from './missing/missing.component';

const  routes:Routes=[
{path:'ping', component: PingComponent},
{path:'missing', component: MissingComponent},
{path:'login',   loadChildren:'./modules/login/login.module#LoginModule'},
// {path:'home', loadChildren:'./modules/home/home.module#HomeModule'},
{path:'home', loadChildren:'./modules/dashboard/dashboard.module#DashboardModule'},
{path:'dashboard', loadChildren:'./modules/dashboard/dashboard.module#DashboardModule'},
{path:'realtime',   canLoad:[GuardService], loadChildren:'./modules/realtime/realtime.module#RealtimeModule'},
{path:'unitreport', canLoad:[GuardService], loadChildren:'./modules/unitreport/unitreport.module#UnitreportModule'},
{path:'gprsdata',   canLoad:[GuardService], loadChildren:'./modules/gprsdata/gprsdata.module#GprsdataModule'},
{path:'revenue',   canLoad:[GuardService], loadChildren:'./modules/revenue/revenue.module#RevenueModule'},
{path:'oem',   canLoad:[GuardService], loadChildren:'./modules/oem/oem.module#OemModule'},
{path:'tamperdetection',   canLoad:[GuardService], loadChildren:'./modules/tamperdetection/tamperdetection.module#TamperdetectionModule'},
{path:'admin/unit',   canLoad:[GuardService], loadChildren:'./modules/admin/unit/unit.module#UnitModule'},
{path:'admin/user',   canLoad:[GuardService], loadChildren:'./modules/admin/user/user.module#UserModule'},
{path:'admin/role',   canLoad:[GuardService], loadChildren:'./modules/admin/role/role.module#RoleModule'},
{path:'admin/organization',   canLoad:[GuardService], loadChildren:'./modules/admin/organization/organization.module#OrganizationModule'},
{path:'admin/oem',   canLoad:[GuardService], loadChildren:'./modules/admin/oem/oem.module#OemModule'},
{path:'billing', loadChildren:'./modules/billing/billing.module#BillingModule'},
{path:'admin/tariff',   canLoad:[GuardService], loadChildren:'./modules/admin/tariff/tariff.module#TariffModule'},
{path:'admin/billgroup',   canLoad:[GuardService], loadChildren:'./modules/admin/billgroup/billgroup.module#BillgroupModule'},
//{path:'billing/view',canLoad:[GuardService], loadChildren:'./modules/billing/billing.module#BillingModule'},
{path:'payment', loadChildren:'./modules/payment/payment.module#PaymentModule'},
{path:'**', component: MissingComponent }
];

export const routing:ModuleWithProviders = RouterModule.forRoot(routes);