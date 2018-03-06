import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { BillingService } from '../../shared/billing.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import  { billGroupInput } from '../../../models/billing/billInput';

@Component({
  selector: 'app-billgroup',
  templateUrl: './billgroup.component.html',
  styleUrls: ['./billgroup.component.scss']
})
export class BillgroupComponent implements OnInit {
 user;
 months=[];
 loaded=false;
 selYear=new Date().getFullYear();
 selMonth=0;
 billDate ;
 dueDate ;
 bgRows=[];
 editRow;
 showEdit=false;
    selectedDivision;
    selectedSubDivision;
    selectedLocation;
    selectedService;
    selectedBillGroup;
 	divisions:KeyValue<number>[]=[];
    subDivisions:KeyValue<number>[]=[];
    servicesList:KeyValue<number>[]=[];
    locationsList:KeyValue<number>[]=[];
    billingTypes:KeyValue<string>[]=[];
    billGroups:KeyValue<string>[]=[];
    selectedBillingType="";
    selectedRowId;
    pagedInput:PagedData<billGroupInput> = new PagedData<billGroupInput>();

  constructor(private commonService:CommonService, private dataService:BillingService) { 

  }

   ngOnInit() {
  	this.user = this.commonService.getCurrentUser();
  	this.months = this.commonService.getMonthNames();
  	this.getList(-1,1);
  	//this.getBillingTypes();
  	this.getBillingGroups();

  	this.billDate = new Date().toISOString().slice(0,10);
  	var nDate = new Date();
	nDate.setDate(new Date().getDate()+15 );// = new Date().getDate()+15;
	this.dueDate = nDate.toISOString().slice(0.,10);
	this.pagedInput.PageNumber = 1;
    this.pagedInput.NumberOfRecords=10;
    this.pagedInput.Data = new billGroupInput();
 
    }

    generate(){

    	if (!this.valid())
    		return;
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		var data ={MonthYear:monyear, Category:this.selectedBillingType, BillDate : this.billDate, DueDate: this.dueDate,DivisionId: this.selectedDivision, SubDivisionId: this.selectedSubDivision};
		this.dataService.generateBill(data).subscribe(res=>{
			let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Bill Generated..");
			}
			else
			{
				this.commonService.showError(result.msg);
			}
			this.loaded=true;
		}, 
			err=>{
				this.commonService.showError("Error occured while generating Bills" );
				this.loaded=true;

			}, 
			()=>{});

	}
	private valid()
	{
		if (this.selectedDivision =="" || this.selectedDivision == undefined)
		{
			this.logError("Select Division");
			return false;
		}
		if (this.selMonth == 0 )
		{
			this.logError("Select Month for Bill Generation");
			return false;
		}
		return true;

	}
	private logError(msg)
	{

		this.commonService.showError(msg);
	}
	addBG(){
		// 		var data = new billGroupInput();
		// data.divisionId = this.selectedDivision;
		// data.subDivisionId = this.selectedSubDivision;
		// data.groupId = this.selectedBillGroup; 
		// this.pagedInput.Data = data;	

		this.dataService.addBG(this.pagedInput.Data).subscribe(res=>{	
			this.bgRows = res.data;
			}, 
					err=>{
						this.commonService.showError("Error occured while generating Bill groups ");
					}, 
					()=>{});	
	}
	edit (rowdata)
	{
		this.showEdit = true;
		this.editRow = rowdata;
		this.selectedRowId = rowdata.id;

	}
	update()
	{
		this.dataService.updateBGitem(this.editRow).subscribe(res=>{
			let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Bill Group updated");


			}
			else
			{
				this.commonService.showError(result.msg);
			}
			this.loaded=true;
			this.showEdit =false;
			this.getBGDetails();
		}, 
			err=>{
				this.commonService.showError("Error occured while updating  Bill Group" );
				this.loaded=true;
				this.showEdit = false;

			}, 
			()=>{});

	}
	validate()
	{

    	if (!this.valid())
    		return;
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		var data ={MonthYear:monyear, Category:this.selectedBillingType, BillDate : this.billDate, 
			DueDate: this.dueDate,DivisionId: this.selectedDivision, SubDivisionId: this.selectedSubDivision};
		this.dataService.generateBill(data).subscribe(res=>{
			let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Bill Generated..");
			}
			else
			{
				this.commonService.showError(result.msg);
			}
			this.loaded=true;
		}, 
			err=>{
				this.commonService.showError("Error occured while generating Bills" );
				this.loaded=true;

			}, 
			()=>{});

	}
	placeChange(selected, typeid)
	{
		this.getList(selected.target.value, typeid);
	}
	// getBillingTypes()
	// {
	// 	var obj="MeterBillingType";
	// 	this.dataService.getMasterValues(obj).subscribe(res=>{	
	// 		this.billingTypes = res;
	// 		}, 
	// 				err=>{
	// 					this.commonService.showError("Error occured while generating Bill groups ");
	// 				}, 
	// 				()=>{});
	// }
	getBillingGroups()
	{
		this.dataService.getBillingGroups().subscribe(res=>{	
			this.billGroups = res;
			}, 
					err=>{
						this.commonService.showError("Error occured while generating Bill groups");
					}, 
					()=>{});
	}
	getBGDetails()
	{
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		var data = new billGroupInput();
		data.divisionId = this.selectedDivision;
		data.subDivisionId = this.selectedSubDivision;
		data.groupId = this.selectedBillGroup; 
		data.monthYear = monyear;
		this.pagedInput.Data = data;	

		this.dataService.getBGdetails(this.pagedInput).subscribe(res=>{	
			this.bgRows = res.data;
			}, 
					err=>{
						this.commonService.showError("Error occured while generating Bill groups ");
					}, 
					()=>{});	
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
						this.commonService.showError ("Error occured while generating Bills ");
					}, 
					()=>{});
			}
	this.loaded=true;
		}


}
