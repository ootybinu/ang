import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router} from '@angular/router';
//import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgbModal , NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { RealtimeService } from '../shared/realtime.service';
import { CommonService} from '../shared/common.service';

import { UserConsumption } from '../../models/realtime/user-consumption';
import { UserConsumptionInput } from '../../models/realtime/user-consumption-input';
import { UserConsumptionSearch } from '../../models/realtime/user-consumption-search';
import { UserConsumptionSearchResponse } from '../../models/realtime/user-consumption-search-response';

import { KeyValue } from '../../models/common/common';
import { MasterData } from '../../models/common/master-data';


import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { ChartComponent }       from '../common/tools/chart/chart.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { RealtimeSearchComponent } from './realtime-search/realtime-search.component';

@Component({
  selector: 'app-realtime',
  templateUrl: './realtime.component.html',
  styleUrls: ['./realtime.component.scss']
})
export class RealtimeComponent implements OnInit {

	realtimeData:UserConsumption[]=[];
	realtimeSearch :UserConsumptionSearch = new UserConsumptionSearch();
	totalpages:number=10;
	message:string="";
	inp = {criteria:""};
	graphdata:{cumalative, dayConsumption};
	graphtype:string='verticalbar';
	graphtype2:string='verticalbar';
	yAxisLabel:string='Daily Consumption';
	xAxisLabel:string ='Unit id';
	g2yAxisLabel:string='Day Consumption';
	g2xAxisLabel:string ='Unit id';
	showgraph:boolean=false;
	showChartIcon:boolean=true;
	prevSort:string="unitid";
	sortByAsc:boolean=true;
	sortColumn:string="unitid";
	enableNext=false;
	filterText:string='';
//	@ViewChild("searchwindow") searchwin;
//	searchwinRef:NgbModalRef;
	//@ViewChild("searchwin") private searchwin:TemplateRef<any>;
	request:PagedData<UserConsumptionInput> = new PagedData<UserConsumptionInput>();

    constructor(private dataService:RealtimeService, private modalService:NgbModal, private commonService:CommonService, private router:Router) { }

    ngOnInit() {

  	  	this.request.PageNumber=1;
	  	this.request.NumberOfRecords=20;

	  	this.request.Data = new UserConsumptionInput();
	  	let user = this.commonService.getCurrentUser();
	  	this.request.Data.UserId = user.employeeId; 
	  	this.request.Data.RoleId=user.roleId;
	  	this.request.Data.OEM=user.oem;
	  	this.request.Data.Designation=user.designation;

	  	this.realtimeSearch.initial = new UserConsumptionSearchResponse();
	  	this.realtimeSearch.initial.Date=new Date().toISOString().slice(0,10);
		//this.request.Data.Criteria = '{OrganizationId:-1, Date:\"' + this.realtimeSearch.initial.Date+'\"}';

	  	if (this.commonService.LocalStore != undefined && this.commonService.LocalStore != null)
	  	{
	  		this.request = this.commonService.LocalStore;
	  		if (this.request.Data != null && this.request.Data.Criteria != undefined && this.request.Data.Criteria!= null)
	  		{
	  		let t = JSON.parse(this.request.Data.Criteria);
	  		if (t.OrganizationText != undefined && t.OrganizationText != null && t.OrganizationText != '' &&  t.OrganizationText != "--All--")
	  		{
	  			this.filterText = "Location = " + t.OrganizationText;
	  		}
	  		this.realtimeSearch.initial.Date = t.Date;
	  		this.commonService.LocalStore = null;
	  		}
	  	}
	  	this.checkEnableNext();
	  	// let now = new Date();
	  	// let seardate = new Date(this.realtimeSearch.initial.Date);
	  	// this.enableNext=  seardate <= new Date( now.getDate()-1);
	 	this.getData();
	  	this.getSearchData();
	  	this.graphdata ={cumalative:[], dayConsumption:[]};

  	}

	pageChanged(nextPage:number){
		this.request.PageNumber=nextPage;
		this.getData();
	}
	getHistory(id){
//		console.log(id);
//		console.log(this.request);
		this.commonService.LocalStore = this.request;
		this.router.navigate(['/realtime/history',id] )	;

	}
	moveto(value)
	{
		let dat =  new Date(this.realtimeSearch.initial.Date); //.getDate()+value;
		dat.setDate(dat.getDate()+value);

		this.realtimeSearch.initial.Date = new Date(dat).toISOString().slice(0,10);
		this.checkEnableNext();
		this.initiateSearch(this.realtimeSearch.initial);
	}
	checkEnableNext()
	{
	  	let now = new Date();
	  	let yester = now.setDate(now.getDate()-1);
	  	//let dt = Date.parse(yester);

	  	let seardate = new Date(this.realtimeSearch.initial.Date);
	  	this.enableNext=  seardate <= now;
	}
	showSearch()
	{
		const searchwin = this.modalService.open(RealtimeSearchComponent);
		searchwin.componentInstance.search = this.realtimeSearch;
		searchwin.result.then(res=> {
			if ( typeof (res) === "object")
			{
				if (Date.parse(res.Date )> Date.parse(Date())){
					res.Date = new Date().toISOString().slice(0,10);
					alert("Future Date not supported.");
				}

				this.initiateSearch(res);

			this.filterText = res.OrganizationText == '--All--'?'': "Location = " + res.OrganizationText;	
			}
			//console.log(res)
		});
	}

	sort(sortby:string)
	{
		if (sortby == this.prevSort)
			this.sortByAsc = ! this.sortByAsc;

		this.request.SortBy = sortby;
		this.request.SortAsc = this.sortByAsc;	
		this.prevSort = sortby;
		this.getData();


	}

	showExport(exportTo:string)
	{
		//alert ("Need to display Export");
		this.getExportData(exportTo);

	}

	showGraph(showTable:boolean)
	{this.showgraph = !showTable;
		if (this.showgraph){
			this.getChartData();
		}
	}
	
	isNotNumeric(ar:any):boolean
	{
		return isNaN(ar)? true: ar==''? true:false;
		//return isNaN(ar);
	}
	private initiateSearch(criteria)
	{
		let response:UserConsumptionSearchResponse = criteria;
		let query = JSON.stringify(criteria); //this.parseCriteria(criteria);
		this.request.Data.Criteria = query;
		if (this.showgraph) {
			this.getChartData();
			this.getData();
		}
		else
			this.getData();

		console.log(query);
	}

	private initialSearchParams()
	{
		let obj1 = new KeyValue<number>();
		obj1.key=-1;
		obj1.value="--All--";

		// let obj2 = new KeyValue<string>();
		// obj2.key='-1';
		// obj2.value='--All--';
		// let obj3 = new MasterData();
		// obj3.code='-1';
  // 		obj3.description='--All--'
		this.realtimeSearch.Organization.unshift(obj1);
		// this.realtimeSearch.RRNumbers.unshift(obj2);
		// this.realtimeSearch.OEM.unshift(obj3);
		this.realtimeSearch.initial.OrganizationId=-1;
		// this.realtimeSearch.initial.RRNumber='-1';
		// this.realtimeSearch.initial.OEM = '-1';
	}

	private processChartData(data:any)
	{
		let arr = [];
		for (var i = 0; i < data.length; ++i) {
			if(!isNaN(data[i].y))
				arr.push({name:data[i].x, value: parseFloat( data[i].y)})
		}
		return arr;
	}
	private processExportData(exportData, exportType){
			let cols=["Division","Sub Division", "Location","Consumer","Today's Consumption","Previous Day Consumption ",
			"Received At","OEM ","Bore Size","Battery voltage","id"];
			let rows =[];
			for (var i = 0; i < exportData.length; ++i) {
				let item = exportData[i];
				if (item.notReceivedToday)
					{
					rows.push([item.division, item.subDivision, item.location,item.name,'',
					'', '',  item.oemName,item.pipeSize,'',item.unitid ]);

					}else 
				{
				rows.push([item.division, item.subDivision, item.location,item.name,item.consumptionInMCube,
					item.dayConsumption, item.addedAt,  item.oemName,item.pipeSize,item.batteryVoltage,item.unitid ]);

				}
			}
			this.commonService.PDFFontSize = 6;
		this.commonService.Export(exportType,'RealData',cols,rows, "Real Time Data", this.filterText);
	}
  	private getData(){

	  	this.dataService.getRealTimeData(this.request).subscribe( t => {
	  		//console.log("Received data ");
	  		this.realtimeData = t.data;
	  		this.totalpages  = this.commonService.getTotalPages(t.totalRecords,this.request.NumberOfRecords);

	  	}, 
	  	err=>{
	  		//this.message="Exception " + err;
	  		console.log("Exception while receving realtime data" + err);
	  		this.commonService.showError(err);	
	  	},
	  	()=>{console.log("Data receive- completed");
	  	});	
  	}

  	private getSearchData()
  	{
  		this.dataService.getRealTimeSearchData(this.request.Data)
  		.subscribe(res => {
  				this.realtimeSearch.Organization = res.organizations; 
  				this.realtimeSearch.RRNumbers = res.rrNumbers;
  				this.realtimeSearch.OEM= res.oem;
  				this.initialSearchParams();

  				//this.realtimeSearch.initial.selectedDate = Date.now().;

  		}, 
  		err=> {
  			console.log('error occured ' + err);
  			this.commonService.showError(err);	
  		}, 
  		()=>{console.log('Completed getting search data');}
  		);


  	}
  	private getChartData()
  	{

 		this.dataService.getRealtimeChartData(this.request.Data)
		  	.subscribe(res => {
				this.graphdata.cumalative = this.processChartData(res.cumalative.data);
		  		this.graphdata.dayConsumption = this.processChartData( res.dayConsumption.data);
  		}, 
  		err=> {
  			console.log('error occured ' + err);
  			this.commonService.showError(err);	
  		}, 
  		()=>{console.log('Completed getting search data');}
  		);

  	}
  	private getExportData(exportType:string)
  	{
  		let req = JSON.parse(JSON.stringify(this.request));
  		req.NumberOfRecords = -1;
  		this.dataService.getRealTimeData(req).subscribe( t => {
	  		console.log("Received data ");
	  		let exportData = t.data;
	  		if (exportData == undefined || exportData == null || exportData.length <=0)
	  			this.commonService.showError("No Records Found to export.");
	  		else 
	  			this.processExportData(exportData, exportType);

	  	}, 
	  	err=>{
	  		//this.message="Exception " + err;
	  		console.log("Exception while receving realtime data" + err);
	  		this.commonService.showError(err);	
	  	},
	  	()=>{console.log("Data receive- completed");
	  	});	

  	}


}
