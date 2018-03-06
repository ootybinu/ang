import { Component, OnInit } from '@angular/core';
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { OemService } from '../shared/oem.service';
import { CommonService } from '../shared/common.service';
import {  oem } from '../../models/oem/oem';
@Component({
  selector: 'app-oem',
  templateUrl: './oem.component.html',
  styleUrls: ['./oem.component.scss']
})
export class OemComponent implements OnInit {
oemRows=[];
oemEffRows=[];
graphData=[];
graphtype:string='verticalbar';
yAxisLabel:string='Efficiency';
xAxisLabel:string ='OEM';
showDetail:boolean=false;
selectedOEM:string="";
  constructor(private dataService:OemService, private commonService:CommonService) { }

  ngOnInit() {
  		this.getData();
  }

  	getDetail(detail)
  	{
  		this.showDetail =true;
  		this.selectedOEM = detail.oemname;
  				this.dataService.getOemEfficiencyDetails(detail.oem).subscribe(res=> {
				this.oemEffRows = res;
				
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
			}, 
		()=>{ });
  	}
  	private processChartData(data:any)
	{
		let arr = [];
		for (var i = 0; i < data.length; ++i) {
			if(!isNaN(data[i].effiency))
				arr.push({name:data[i].oemname, value: parseFloat( data[i].effiency)})
		}
		return arr;
	}

  	private getData(){

		this.dataService.getOemEffiency ().subscribe(res=> {
				this.oemRows = res;
				this.graphData = this.processChartData(res);
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
			}, 
		()=>{ });
	}

}
