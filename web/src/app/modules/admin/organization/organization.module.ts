import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { OrganizationComponent } from './organization.component';
import { CommonService } from '../../shared/common.service';
import { ToolsModule } from  '../../common/tools/tools.module';
import { HttpClientService } from '../../shared/http-client.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const routes:Routes=[{path:'', component:OrganizationComponent}];
@NgModule({
  imports: [
    CommonModule,
    ToolsModule,
    FormsModule,
    RouterModule.forChild(routes),
    NgbModule
  ],
  declarations: [OrganizationComponent]
})
export class OrganizationModule { }
