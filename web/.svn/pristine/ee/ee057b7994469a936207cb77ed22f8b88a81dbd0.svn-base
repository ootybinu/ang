import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { CommonService} from '../shared/common.service';
import { ToolsModule } from  '../common/tools/tools.module';
import { HttpClientService } from '../shared/http-client.service';
import { UnitreportService } from '../shared/unitreport.service';
import { UnitreportComponent } from './unitreport.component';
import { UnitreportSearchComponent } from './unitreport-search/unitreport-search.component';

const routes:Routes=[{path:'', component:UnitreportComponent}];
@NgModule({
  imports: [
    CommonModule, 
    FormsModule,
    ToolsModule,
    RouterModule.forChild(routes)
  ],
  providers: [HttpClientService, UnitreportService,CommonService],
  declarations: [UnitreportComponent, UnitreportSearchComponent]	
})
export class UnitreportModule { }
