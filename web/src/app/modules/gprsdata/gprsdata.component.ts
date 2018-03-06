import { Component, OnInit } from '@angular/core';
import { GprsdataService } from '../shared/gprsdata.service';
import { CommonService} from '../shared/common.service';

import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { gprsdata } from '../../models/gprsdata/gprsdata';
@Component({
  selector: 'app-gprsdata',
  templateUrl: './gprsdata.component.html',
  styleUrls: ['./gprsdata.component.scss']
})
export class GprsdataComponent implements OnInit {
	showExportIcon:boolean=false;
	showChartIcon:boolean=false;
	showSearchPanel:boolean=true;
	userSelectedDate:string;

	gprsRows :gprsdata[]=[];
  constructor(private dataService:GprsdataService, private commonService:CommonService) { }

  ngOnInit() {
  	this.userSelectedDate = new Date().toISOString().slice(0,10);
  }
	showSearch(){
		this.showSearchPanel = ! this.showSearchPanel;
	}
	searchClicked()
	{

		this.showSearchPanel= false;
		this.getData();

	}
	hidePanel()
	{
		this.showSearchPanel = false;
	}

	private getData(){

		this.dataService.getGprsData(this.userSelectedDate).subscribe(res=> {
			this.gprsRows = res;
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
			}, 
		()=>{ });
	}
}
