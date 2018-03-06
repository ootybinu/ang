import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { PaymentService } from '../../shared/payment.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import  { billGroupInput } from '../../../models/billing/billInput';
import { billInput }  from '../../../models/billing/billInput';
@Component({
  selector: 'app-paymentprocess',
  templateUrl: './paymentprocess.component.html',
  styleUrls: ['./paymentprocess.component.scss']
})
export class PaymentprocessComponent implements OnInit {
 user;
 months=[];
 loaded=false;
 selYear=new Date().getFullYear();
 selMonth=0;
     selectedDivision;
    selectedBillGroup;
 	divisions:KeyValue<number>[]=[];
    billingTypes:KeyValue<string>[]=[];
    billGroups:KeyValue<number>[]=[];
    billGroup;
    selectedBillingType="";
    billDate;
    pdata=[];
    pagedInput:PagedData<billGroupInput> = new PagedData<billGroupInput>();
    totalpages:number=10;
	constructor(private commonService:CommonService, private dataService:PaymentService) { }

  ngOnInit() {
  	this.user = this.commonService.getCurrentUser();
  	this.months = this.commonService.getMonthNames();
  	this.pagedInput.PageNumber = 1;
    this.pagedInput.NumberOfRecords=20;
    this.pagedInput.Data = new billGroupInput();
  	this.getList(-1,1);
  	//this.getBillingTypes();
  	//this.getBillingGroups();

  	this.billDate = new Date().toISOString().slice(0,10);
  	var nDate = new Date();
	nDate.setDate(new Date().getDate()+15 );// = new Date().getDate()+15;
	//this.dueDate = nDate.toISOString().slice(0.,10);
  }
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
	process(){
		let mon = this.selMonth >= 10 ?''+this.selMonth:'0' + this.selMonth;
		let monyear = mon+this.selYear;
		
		this.pagedInput.Data.monthYear = monyear;
		this.pagedInput.Data.divisionId = this.selectedDivision;
		this.pagedInput.Data.groupId = this.selectedBillGroup;

		this.dataService.processPayment(this.pagedInput).subscribe(res=>{	
			this.pdata = res.data;
          this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
			}, 
					err=>{
						this.commonService.showError("Error occured while payment Processing");
					}, 
					()=>{});
	}

}
