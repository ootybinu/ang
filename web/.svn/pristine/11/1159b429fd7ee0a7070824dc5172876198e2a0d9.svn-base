import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { BillingService } from '../../shared/billing.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import  { billGroupInput } from '../../../models/billing/billInput';
import { billInput }  from '../../../models/billing/billInput';
import { BilldetailComponent} from './../viewbill/billdetail/billdetail.component';
@Component({
  selector: 'app-genbill',
  templateUrl: './genbill.component.html',
  styleUrls: ['./genbill.component.scss']
})
export class GenbillComponent implements OnInit {
 user;
 months=[];
 loaded=false;
 selYear=new Date().getFullYear();
 selMonth=0;
 billDate ;
 dueDate ;
 bgRows=[];
 showDetailPanel=false;
 totalpages:number=10;  
    selectedDivision;
    selectedBillGroup;
 	divisions:KeyValue<number>[]=[];
    billingTypes:KeyValue<string>[]=[];
    billGroups:KeyValue<number>[]=[];
    billGroup;
    selectedBillingType="";
    showBillsPanel:boolean=false;
    pagedInput:PagedData<billGroupInput> = new PagedData<billGroupInput>();
    bills =[];

  constructor(private commonService:CommonService, private dataService:BillingService) { 

  }

   ngOnInit() {
  	this.user = this.commonService.getCurrentUser();
  	this.months = this.commonService.getMonthNames();
  	this.getList(-1,1);
  	//this.getBillingTypes();
  	//this.getBillingGroups();

  	this.billDate = new Date().toISOString().slice(0,10);
  	var nDate = new Date();
	nDate.setDate(new Date().getDate()+15 );// = new Date().getDate()+15;
	this.dueDate = nDate.toISOString().slice(0.,10);
	this.pagedInput.PageNumber = 1;
    this.pagedInput.NumberOfRecords=10;
    this.pagedInput.Data = new billGroupInput();
 
    }
	    generate(){

  //   	if (!this.valid())
  //   		return;
		// let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		// let monyear = mon+this.selYear;
		// var data ={MonthYear:monyear, Category:this.selectedBillingType, BillDate : this.billDate, DueDate: this.dueDate,DivisionId: this.selectedDivision, SubDivisionId: this.selectedSubDivision};
		this.dataService.generateBillBGwise(this.selectedBillGroup).subscribe(res=>{
			let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Bill Generated..");
				this.getBillGroup();
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
	print()
	{
		this.showBillsPanel=true;
		this.getPrintData();

	}
	getBillGroups(){
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		var data ={MonthYear:monyear, DivisionId: this.selectedDivision };
		this.dataService.getBGList(data).subscribe(res=>{	
			this.billGroups = res;
			}, 
					err=>{
						this.commonService.showError("Error occured while generating Bill groups");
					}, 
					()=>{});
	}
	getBillGroup(){
		// let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		// let monyear = mon+this.selYear;
		// var data ={MonthYear:monyear, DivisionId: this.selectedDivision };
		this.dataService.getBillGroup(this.selectedBillGroup).subscribe(res=>{	
			this.billGroup = res;
			this.showDetailPanel=true;
			}, 
					err=>{
						this.commonService.showError("Error occured while getting Bill group");
					}, 
					()=>{});
	}

	getPrintData(){
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		this.pagedInput.Data.monthYear= monyear;
		this.pagedInput.Data.divisionId = this.selectedDivision;
		this.pagedInput.Data.groupId = this.selectedBillGroup;
//		var data ={MonthYear:monyear, DivisionId: this.selectedDivision, GroupId:this.selectedBillGroup };
		this.dataService.getBillsforPrint(this.pagedInput).subscribe(res=>{	
			this.bills = res.data;
			this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
			}, 
					err=>{
						this.commonService.showError("Error occured while Getting  Bills");
					}, 
					()=>{});
	}
	printAll()
	{
		let divContents = document.getElementById("printPanel").innerHTML;
		let printWindow = window.open('', '', 'height=200,width=400');  
        printWindow.document.write('<html><head><title>Print DIV Content</title>');  
        printWindow.document.write('</head><body >');  
        printWindow.document.write(divContents);  
        printWindow.document.write('</body></html>');  
        printWindow.document.close();  
        printWindow.print();  
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
	// addBG(){
	// 	this.dataService.addBG(this.pagedInput.Data).subscribe(res=>{	
	// 		this.bgRows = res.data;
	// 		}, 
	// 				err=>{
	// 					this.commonService.showError("Error occured while generating Bill groups ");
	// 				}, 
	// 				()=>{});	
	// }
	validate()
	{

    	if (!this.valid())
    		return;
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		var data ={MonthYear:monyear, Category:this.selectedBillingType, BillDate : this.billDate, 
			DueDate: this.dueDate,DivisionId: this.selectedDivision};
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
	// getBGDetails()
	// {
	// 	let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
	// 	let monyear = mon+this.selYear;
	// 	var data = new billGroupInput();
	// 	data.divisionId = this.selectedDivision;
	// 	data.groupId = this.selectedBillGroup; 
	// 	data.monthYear = monyear;
	// 	this.pagedInput.Data = data;	

	// 	this.dataService.getBGdetails(this.pagedInput).subscribe(res=>{	
	// 		this.bgRows = res.data;
	// 		}, 
	// 				err=>{
	// 					this.commonService.showError("Error occured while generating Bill groups ");
	// 				}, 
	// 				()=>{});	
	// }
	getList(evt, typeid){
		var obj ={parentId:evt, typeId:typeid};

			if (evt != ""){
			this.dataService.getPlaceList(obj).subscribe(res=>{
			switch (typeid.toString()) {
				case "1":
				this.divisions = res;
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
