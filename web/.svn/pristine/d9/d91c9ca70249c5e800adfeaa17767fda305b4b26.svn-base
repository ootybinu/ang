import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
import { TariffService } from '../../shared/tariff.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { User } from '../../../models/common/user';
import { tariff } from '../../../models/tariff/tariff';

import {KeyValue}  from '../../../models/common/common';

@Component({
  selector: 'app-tariff',
  templateUrl: './tariff.component.html',
  styleUrls: ['./tariff.component.scss']
})
export class TariffComponent implements OnInit {
	user;
	loaded=false;
	divisions:KeyValue<number>[]=[];
	selectedDivision:number;
	selectedYear:number;
	data=[];
	pagedInput:PagedData<any> = new PagedData<any>();
	oemRows=[];
	totalpages:number=10;
	editMode:boolean=false;
	addNew:boolean=false;
	currentRow:any;
	metertype=[];
	selectedRowId;

  
  constructor(private dataService:TariffService , private commonService:CommonService) { }

  	ngOnInit() {
  		this.pagedInput.PageNumber = 1;
    	this.pagedInput.NumberOfRecords=20;
  		this.getInitData();
  	}

	pageChanged(nextPage:number){
	    this.pagedInput.PageNumber=nextPage;
	    this.getData();
	}
	getInitData()
	{
		 let obj ={parentId:-1, typeId:1};
		//let  obj ={};
		this.dataService.getPlaceList(obj).subscribe(res=>{
			this.divisions = res;
		}, 
		err=>{
			this.commonService.showError("Error occured while Getting Divisions");
		}, 
		()=>{});


	}
	generate ()
	{
		let obj = {divisionid :this.selectedDivision, year: this.selectedYear };
		this.dataService.generate(obj).subscribe(res=>{
		let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Tariff Configuration Generated..");
			}
			else
			{
				this.commonService.showError(result.msg);
			}
			this.loaded=true;
		}, 
		err=>{
			this.commonService.showError("Error occured while Generatting Tariff Configurations ");
		}, 
		()=>{});

	}
	getData()
	{
		let obj = {divisionid :this.selectedDivision, year: this.selectedYear };
		this.pagedInput.Data = obj;
		this.dataService.getData(this.pagedInput).subscribe(res=>{
			this.data = res.data;
			this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
			this.loaded=true;
			}, 
			err=>{
				this.commonService.showError("Error occured while Generatting Tariff Configurations ");
			}, 
			()=>{});
	}
	edit(row)
	{
		this.editMode = true;
		this.currentRow = row;
		this.selectedRowId = row.id;
	}
	add()
	{
		this.addNew = true;
		this.editMode = true;
		this.currentRow = new tariff();
		this.dataService.getMeterType('MeterBillingType').subscribe(res=>{
			this.metertype = res;
			this.loaded=true;
			}, 
			err=>{
				this.commonService.showError("Error occured while Generatting Tariff Configurations ");
			}, 
			()=>{});

	}
	delete(row)
	{
		this.selectedRowId = row.id;
   		let ans = confirm("Are you sure ?");
	   		if (ans)
	   		{
	   			this.dataService.delete(row).subscribe(res=>{
	   				let  result = 	JSON.parse(res);
	  		    if (result.msg =="Success")
		        {  
		          	this.commonService.showSuccess("Data Removed Successfully","Deleted");
		          	this.getData();
		        }else
		          {
		          	this.commonService.showError("Not Deleted " + res.msg);
		          }
		        }, err=>{
		          console.log('Error occured '+ err);
		          this.commonService.showError(err);
	 
	  	        } ,()=>{}); 
	  		}
	
	}
	save()
	{
		if (this.addNew)
		{
			this.currentRow.divisionId =  this.selectedDivision*1;
			this.currentRow.year = this.selectedYear;
		}
		this.editMode=false;
		this.addNew=false;
		//let obj = {divisionid :this.selectedDivision, year: this.selectedYear };
		this.dataService.update(this.currentRow ).subscribe(res=>{
		let  result = 	JSON.parse(res);
			if (result.msg=="Success")
			{
				this.commonService.showSuccess("Tariff Configuration Updated..");
				this.getData();
			}
			else
			{
				this.commonService.showError(result.msg);
			}
			this.loaded=true;
		}, 
		err=>{
			this.commonService.showError("Error occured while Updating Tariff Configurations ");
		}, 
		()=>{});

	}
}
