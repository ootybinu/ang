import { Component, OnInit } from '@angular/core';
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { TamperdetectionService } from '../shared/tamperdetection.service';
import { CommonService } from '../shared/common.service';
import { orginput, orgShort } from '../../models/organization/organization';
import { tamperinput} from '../../models/tamperdetection/tamper';
@Component({
  selector: 'app-tamperdetection',
  templateUrl: './tamperdetection.component.html',
  styleUrls: ['./tamperdetection.component.scss']
})
export class TamperdetectionComponent implements OnInit {
	showExportIcon:boolean=false;
	showChartIcon:boolean=false;
	showSearchPanel:boolean=true;
	divisions=[];
	subDivisions=[];
	serviceStations=[];
	locations=[];
	units=[];
	tamperdata=[];
	selectedDivision:string;
	selectedSubDivision:string;
	selectedLocation:string;
	selectedServiceStation:string;
	selectedUnit:string;
	pagedinput:PagedData<tamperinput> = new PagedData<tamperinput>();
	totalpages:number=10;

  constructor(private dataService:TamperdetectionService, private commonService:CommonService) { }

  ngOnInit() {
  	var inp =new orginput();
 		this.pagedinput.PageNumber = 1;
 		this.pagedinput.NumberOfRecords=20;
  	this.fillData(this.divisions, inp);
  }

  getSubItems(ctrl, evt)
  {
  	let val = evt.target.value;
  	let inp = new orginput();
  	inp.parentid = val;
  	switch (ctrl) {
  		case 1:
  		this.serviceStations.length=0;
  		this.locations.length =0;
  		this.units.length=0;
  		this.fillData(this.subDivisions,inp );	
  			// code...
  			break;
  		case 2:
  	  		this.locations.length =0;
	  		this.units.length=0;
  			this.fillData(this.serviceStations, inp);
  			break;
  		case 3:
	  		this.units.length=0;
  			this.fillData(this.locations, inp);
  			break;
  		case 4:
  			this.fillUnitData(this.units, inp);
  			break;

  		default:
  			// code...
  			break;
  	}
  }

  search()
  {

  	let criteria = this.getCriteria();
  	let tamcrit = new tamperinput();
  	tamcrit.criteria = criteria;
  	this.pagedinput.Data = tamcrit;
  	this.getData(this.pagedinput);
  }
	pageChanged(nextPage:number){
		this.pagedinput.PageNumber=nextPage;
		this.getData(this.pagedinput);
	}
  private getCriteria()
  {
  	let crit="";
  	if (this.selectedUnit != undefined && this.selectedUnit !="")
  			crit="unitid = '" + this.selectedUnit + "'";
  	else 
  	if (this.selectedLocation != undefined && this.selectedLocation !="")
  			crit="locationid = " + this.selectedLocation ;
  	  	else 
  	if (this.selectedServiceStation != undefined && this.selectedServiceStation !="")
  			crit="servicestnid = " + this.selectedServiceStation ;
  	else 
  	if (this.selectedSubDivision != undefined && this.selectedSubDivision !="")
  			crit="subdivisionid = " + this.selectedSubDivision ;
  	else 
  	if (this.selectedDivision != undefined && this.selectedDivision !="")
  			crit="divisionid = " + this.selectedDivision ;

  	return crit;	

  }
  private fillData(arr, criteria)
  {
  	this.dataService.getList(criteria).subscribe(res=>{
  		while(arr.length !=0)
	  		arr.pop();
	  	for (var i = 0; i < res.length; ++i) {
	  		arr.push(res[i]);
	  	}

		}, 
		err=> {
			console.log('Error occured '+ err);
		    this.commonService.showError(err);  
		}, 
		()=>{ });

  }

  private fillUnitData(arr, criteria)
  {
  	this.dataService.getUnitList(criteria).subscribe(res=>{
  		while(arr.length !=0)
	  		arr.pop();
	  	for (var i = 0; i < res.length; ++i) {
	  		arr.push(res[i]);
	  	}

		}, 
		err=> {
			console.log('Error occured '+ err);
		    this.commonService.showError(err);  
		}, 
		()=>{ });

  }
    private getData( criteria)
  {
  	this.dataService.getData(criteria).subscribe(res=>{
		this.tamperdata = res.data;
		this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedinput.NumberOfRecords);
		}, 
		err=> {
			console.log('Error occured '+ err);
		    this.commonService.showError(err);  
		}, 
		()=>{ });

  }
}
