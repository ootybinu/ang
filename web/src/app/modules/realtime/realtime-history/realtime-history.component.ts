import { Component, OnInit ,OnDestroy} from '@angular/core';
import { ActivatedRoute} from '@angular/router'
import { Location } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { RealtimeService } from '../../shared/realtime.service';
import { CommonService} from '../../shared/common.service';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { ChartComponent }       from '../../common/tools/chart/chart.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { UserConsumptionHistory, UserConsumptionHistoryInput } from '../../../models/realtime/user-consumption-history';

@Component({
  selector: 'app-realtime-history',
  templateUrl: './realtime-history.component.html',
  styleUrls: ['./realtime-history.component.scss']
})
export class RealtimeHistoryComponent implements OnInit {

	id:any;
	request:PagedData<UserConsumptionHistoryInput>;
	response:PagedResponse<UserConsumptionHistory>;
	historyItems:UserConsumptionHistory[]=[];
	graphdata:{cumalative, dayConsumption};
	totalpages:number=10;
	showgraph:boolean=false;
	message:string;
	graphtype:string='line';
	yAxisLabel:string='Cumulative Consumption';
	xAxisLabel:string ='Unit id';
	private sub:any;
	filterText:string='';


  	constructor(private dataService:RealtimeService, private route:ActivatedRoute, private commonService:CommonService, private location:Location) { 
  	}

  	ngOnInit() {
  		this.sub =   	this.route.params.subscribe(params => {
	  		this.id = +params['id'];
  			this.request = new 	PagedData<UserConsumptionHistoryInput>();
  			this.request.PageNumber=1;
	  		this.request.NumberOfRecords=20;
  			this.request.Data = new UserConsumptionHistoryInput();
  			this.request.Data.unitid = this.id;
  			let user = this.commonService.getCurrentUser();
  			this.request.Data.role=user.roleId; 
  			this.graphdata ={cumalative:[], dayConsumption:[]};
  			this.getData();

  		});
  	}

  	ngOnDestroy()
  	{
  		this.sub.unsubscribe();
  	}

  	pageChanged(nextPage:number){
		this.request.PageNumber=nextPage;
		this.getData();
	}

	showExport(exportTo:string)
	{
		//alert ("Need to display Export");
		this.getExportData(exportTo);

	}

	showGraph()
	{
		this.showgraph = ! this.showgraph;
		if (this.showgraph){
			this.getChartData();
		}
	}
	back()
	{
		this.location.back();
	}
		private processExportData(exportData, exportType){

			let cols=["OEM Name ","Date ","Time ","Consumption ","Pulse Count ","Battery voltage","Tamper Status","Unit Id"];
			let rows =[];
			for (var i = 0; i < exportData.length; ++i) {
				let item = exportData[i];
				rows.push([item.oemName,item.date.substring(0,10) ,item.time,item.consumptionInMCube,item.pulseCount,item.batteryVoltage, item.tamperStatus, item.unitId]);
			}
			this.commonService.PDFFontSize = 8;
		this.commonService.Export(exportType,'RealData',cols,rows,"Historic Data","");
	}

	private processChartData(data:any)
	{
		let arr = [];
		for (var i = 0; i < data.length; ++i) {
			arr.push({name:data[i].x, value: parseFloat( data[i].y)})
		}
		let ob =[{"name":"Series", "series":arr}];
		return ob;
	}
  	private getData(){
  		this.dataService.getRealtimeHistory(this.request).subscribe(
  			data=> {
  				this.historyItems = data.data;
  				this.totalpages = this.commonService.getTotalPages(data.totalRecords ,this.request.NumberOfRecords);
  			}, err=> {
  				console.log('Exception occured while fetching Realtime History ' + err);

  			} ,()=> {

  			});
  	}
  	private getChartData()
  	{

  		  		this.dataService.getRealtimeHistoryChart(this.request.Data)
  		.subscribe(res => {

			this.graphdata.cumalative = this.processChartData(res.cumalative.data);
  				//this.graphdata.cumalative = res.cumalative.data;
  				this.graphdata.dayConsumption = this.processChartData(res.dayConsumption.data);


  				//this.realtimeSearch.initial.selectedDate = Date.now().;

  		}, 
  		err=> {
  			console.log('error occured ' + err);
  		}, 
  		()=>{console.log('Completed getting search data');}
  		);

  	}
  	private getExportData(exportType:string)
  	{
  		let req = JSON.parse(JSON.stringify(this.request));
  		req.NumberOfRecords = -1;
  		this.dataService.getRealtimeHistory(req).subscribe( t => {
	  		console.log("Received data ");
	  		let exportData = t.data;
	  		this.processExportData(exportData, exportType);

	  	}, 
	  	err=>{
	  		this.message="Exception " + err;
	  		console.log("Exception while receving realtime data" + err);
	  	},
	  	()=>{console.log("Data receive- completed");
	  	});	

  	}
}
