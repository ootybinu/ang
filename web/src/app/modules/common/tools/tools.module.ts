import { NgModule } from '@angular/core';
import { Input, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './pagination/pagination.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { TableHelperComponent } from './table-helper/table-helper.component';
import { ChartComponent } from './chart/chart.component';
import { TitleComponent } from './title/title.component';
import { BilldetailComponent} from './billdetail/billdetail.component'
import { RouterModule } from '@angular/router';
//import { BrowserAnimationsModule } from '@angular/plat;form-browser/animations';

@NgModule({
  imports: [
    CommonModule, FormsModule, NgxChartsModule,RouterModule
  ],
  exports : [PaginationComponent, TableHelperComponent, ChartComponent,TitleComponent,BilldetailComponent],
  declarations: [PaginationComponent, TableHelperComponent,  ChartComponent, TitleComponent,BilldetailComponent]
})
export class ToolsModule { 
}
