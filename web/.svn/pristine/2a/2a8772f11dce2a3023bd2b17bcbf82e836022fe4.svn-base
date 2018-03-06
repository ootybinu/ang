import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonService } from '../../shared/common.service';
import { ToolsModule } from  '../../common/tools/tools.module';
import { HttpClientService } from '../../shared/http-client.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OemComponent } from './oem.component';

const routes:Routes=[{path:'', component:OemComponent}];

@NgModule({
  imports: [
     CommonModule,
     ToolsModule,
     FormsModule,
    RouterModule.forChild(routes),
    NgbModule
  ],
  providers: [HttpClientService, CommonService],
  declarations: [OemComponent]
})
export class OemModule { }
