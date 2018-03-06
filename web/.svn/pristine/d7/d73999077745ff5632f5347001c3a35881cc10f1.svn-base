import { Component, OnInit } from '@angular/core';
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { RevenueService } from '../shared/revenue.service';
import { CommonService } from '../shared/common.service';
import { revenueInput } from '../../models/revenue/revenue';

@Component({
  selector: 'app-revenue',
  templateUrl: './revenue.component.html',
  styleUrls: ['./revenue.component.scss']
})
export class RevenueComponent implements OnInit {
	revenueRows=[];
	showExportIcon:boolean=true;
	showChartIcon:boolean=false;
	showSearchPanel:boolean=true;
	totalpages:number=10;
	totalRevenue:number;
	rinput:revenueInput;
	pagedinput:PagedData<revenueInput> = new PagedData<revenueInput>();
	revenueData=[];
  constructor(private dataService:RevenueService, private commonService:CommonService) { }

  ngOnInit() {

  		this.pagedinput.PageNumber = 1;
  		this.pagedinput.NumberOfRecords=10;

  		let dat = new Date();
  		let fr = new Date();
  		this.rinput = new revenueInput();
  		fr.setMonth(fr.getMonth() -1);
  		this.rinput.fromDate=fr.toISOString().slice(0,10);
  		this.rinput.toDate= dat.toISOString().slice(0,10);
  		this.pagedinput.Data = this.rinput;

  		this.getInitData();
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
	pageChanged(nextPage:number){
		this.pagedinput.PageNumber=nextPage;
		this.getData();
	}
		showExport(exportTo:string)
	{
		//alert ("Need to display Export");
		this.getExportData(exportTo);

	}

	private processExportData(exportData, exportType){

			let cols=["Division","Sub Division","RR No.","Consumption","Revenue Generated ","Consumer","OEM","Unit"];
			let rows =[];
			for (var i = 0; i < exportData.length; ++i) {
				let item = exportData[i];
				rows.push([item.division,item.subDivision,item.rRnumber,item.totalConsumption,item.revenue,item.name,item.oem,item.unit]);
			}
			this.commonService.PDFFontSize = 8;
		this.commonService.Export(exportType,'RevenueData',cols,rows,"Revenue Data","");
		// let header =`<tr>
		// 		<th>Division</th>
		// 		<th>Sub Division</th>
		// 		<th>RR No.</th>
		// 		<th>Consumption</th>
		// 		<th>Revenue Generated </th>
		// 		<th>Consumer</th>
		// 		<th>OEM</th>
		// 		<th>Unit</th>
		// 	</tr>`;
		// let body =``;
		// for (var i = 0; i < exportData.length; ++i) {
		// 	let item = exportData[i];
		// 	body+='<tr>';
		// 	body+= '<td>' + item.division + '</td>';
		// 	body+= '<td>' + item.subDivision + '</td>';
		// 	body+= '<td>' + item.rRnumber + '</td>';
		// 	body+= '<td>' + item.totalConsumption + '</td>';
		// 	body+= '<td>' + item.revenue + '</td>';
		// 	body+= '<td>' + item.name + '</td>';
		// 	body+= '<td>' + item.oem + '</td>';
		// 	body+= '<td>' + item.unit + '</td>';
		// 	body+='</tr>';
		// }
		// let finaldata ='<table>' + header + body + '</table>';
		// this.commonService.Export(exportType,'RevenueData',finaldata);
	}
	private getData(){

		this.dataService.getRevenueData (this.pagedinput).subscribe(res=> {
				this.revenueData = res.data;
				this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedinput.NumberOfRecords);
				this.totalRevenue = parseInt(res.metaData);
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
			}, 
		()=>{ });
	}

	private getInitData()
	{
		this.dataService.getDivisions(1).subscribe(res=>{
			this.rinput.divisions = res;
			let obj1 = {key:"0", value:"All"};
			this.rinput.divisions.unshift(obj1);
		}, 
		err=>{
			console.log('Error occured '+ err);
			this.commonService.showError(err);
		},()=>{

		})
	}

	private getExportData(exportType:string)
  	{
  		let req = JSON.parse(JSON.stringify(this.pagedinput));
  		req.NumberOfRecords = -1;
  		this.dataService.getRevenueData(req).subscribe( t => {
	  		console.log("Received data ");
	  		let exportData = t.data;
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
