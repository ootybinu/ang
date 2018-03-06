import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { OemComponent } from './oem.component';
import { CommonService } from '../shared/common.service';
import { OemService } from '../shared/oem.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
const routes:Routes=[{path:'', component:OemComponent}];
@NgModule({
  imports: [
    CommonModule,
    ToolsModule,
    FormsModule,
    RouterModule.forChild(routes)
  ],
   providers: [HttpClientService, CommonService,OemService],
  declarations: [OemComponent]
})
export class OemModule { }
