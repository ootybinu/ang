import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { BillingService } from '../../shared/billing.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 
import { billInput }  from '../../../models/billing/billInput';
import { BilldetailComponent} from '../../common/tools/billdetail/billdetail.component';
@Component({
  selector: 'app-viewbill',
  templateUrl: './viewbill.component.html',
  styleUrls: ['./viewbill.component.scss']
})
export class ViewbillComponent implements OnInit {
	user;
 	months=[];
 	 loaded=false;
	showExportIcon:boolean=false;
	showChartIcon:boolean=false;
	showSearchPanel:boolean=true;
	totalpages:number=10;
	divisions:KeyValue<number>[]=[];
    subDivisions:KeyValue<number>[]=[];
    servicesList:KeyValue<number>[]=[];
    locationsList:KeyValue<number>[]=[];
    consumerList:KeyValue<number>[]=[];
	pagedInput:PagedData<billInput> = new PagedData<billInput>();
	billinput:billInput;
	billdetails=[];
	selYear=new Date().getFullYear();
    selMonth=0;
    selectedDivision;
    selectedSubDivision;
    selectedLocation;
    selectedService;

  constructor(private commonService:CommonService, private dataService:BillingService) { }

  ngOnInit() {
  	  	this.months = this.commonService.getMonthNames();
  	  	this.getList(-1,1);
		this.pagedInput.PageNumber = 1;
  		this.pagedInput.NumberOfRecords=4;
  }
	showSearch(){
		this.showSearchPanel = ! this.showSearchPanel;
	}
	placeChange(selected, typeid)
	{
		this.getList(selected.target.value, typeid);
	}

	applyFilter(){

		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		this.billinput = new billInput();
		this.billinput.monthYear = monyear;
		this.billinput.divisionId = this.selectedDivision;
		this.billinput.subDivisionId = this.selectedSubDivision
		this.billinput.serviceId = this.selectedService;
		this.billinput.locationId = this.selectedLocation;

		this.getData(this.billinput );


	}

	pageChanged(nextPage:number){
	  this.pagedInput.PageNumber=nextPage;
	  this.getData(this.billinput);
	}

	private getData(search) {
		this.pagedInput.Data  = search;
		this.dataService.getBills(this.pagedInput).subscribe(res=> {
			this.billdetails = res.data;
			this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}

	getList(evt, typeid){
		var obj ={parentId:evt, typeId:typeid};
		switch (typeid.toString()) {
				case "2":
				this.subDivisions= undefined;
				this.servicesList = undefined;
				this.locationsList = undefined;
				this.selectedService=""; 
				this.selectedLocation=""; this.selectedSubDivision="";

					break;
				case "4":
				this.servicesList = undefined; 
				this.locationsList=undefined;
				this.selectedService=""; 
				this.selectedLocation="";
				
					break;
				case "3":
				this.locationsList = undefined;
				this.selectedLocation="";
					break;
				default:
					// code...
					break;
				}
			if (evt != ""){
			this.dataService.getPlaceList(obj).subscribe(res=>{
			switch (typeid.toString()) {
				case "1":
				this.divisions = res;
					break;
				case "2":
				this.subDivisions = res;
					break;
				case "4":
				this.servicesList = res;
					break;
				case "3":
				this.locationsList = res;
					break;
				default:
					// code...
					break;
				}
				
				}, 
					err=>{
						this.commonService.showSuccess("Error occured while generating Bills ","Exception");
					}, 
					()=>{});
			}
	this.loaded=true;
		}
}
