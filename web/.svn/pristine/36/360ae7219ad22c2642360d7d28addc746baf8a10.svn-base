import { Component, OnInit } from '@angular/core';
import { UnitreportService } from '../shared/unitreport.service';
import { CommonService} from '../shared/common.service';

import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { searchResult } from '../../models/unitreport/searchList';
import { unitreport } from '../../models/unitreport/unitreport';
@Component({
  selector: 'app-unitreport',
  templateUrl: './unitreport.component.html',
  styleUrls: ['./unitreport.component.scss']
})
export class UnitreportComponent implements OnInit {
	showExportIcon:boolean=false;
	showChartIcon:boolean=false;
	showSearchPanel:boolean=true;
	unitreports :unitreport[]=[];
	pagedInput:PagedData<searchResult> = new PagedData<searchResult>();
	searchResult:searchResult;
	totalpages:number=10;
	
	constructor(private dataService:UnitreportService, private commonService:CommonService) { }

  	ngOnInit() {
  		this.pagedInput.PageNumber = 1;
  		this.pagedInput.NumberOfRecords=20;

  	}
	showSearch(){
		this.showSearchPanel = ! this.showSearchPanel;
	}
	selected(evt:searchResult)
	{
	this.searchResult = evt;	
		this.showSearchPanel = false;
		this.getData(evt);

	}
	switchPanel(flag:boolean)
	{
		this.showSearchPanel = flag;
	}
	pageChanged(nextPage:number){
	  this.pagedInput.PageNumber=nextPage;
	  this.getData(this.searchResult);
	}
	private getData(search:searchResult) {
		this.pagedInput.data = search;
		this.dataService.getUnitReport(this.pagedInput).subscribe(res=> {
			this.unitreports = res.data;
			this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}
}
