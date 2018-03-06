import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
import { BillingService } from '../../shared/billing.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import {KeyValue}  from '../../../models/common/common';
import  { bgInput } from '../../../models/billing/billInput';
@Component({
  selector: 'app-billgroup',
  templateUrl: './billgroup.component.html',
  styleUrls: ['./billgroup.component.scss']
})
export class BillgroupComponent implements OnInit {
	divisions:KeyValue<number>[]=[];
	bgRows =[];
	selectedDivision;
	current ;
	showDetailPanel:boolean = false;
	pagedInput:PagedData<bgInput> = new PagedData<bgInput>();
	selectedRowId;
  constructor(private dataService:BillingService , private commonService:CommonService ) { }

  ngOnInit() {
  	this.getList(-1,1);
  		this.pagedInput.PageNumber = 1;
    this.pagedInput.NumberOfRecords=10;
    this.pagedInput.Data = new bgInput();
  }

	getData()
	{
		if (this.selectedDivision == undefined)
		{
			this.commonService.showError("Please select Division");
			return;
		}
		let data = new bgInput();
		data.divisionId = this.selectedDivision;
		this.pagedInput.Data = data;
		this.dataService.getBGMaster(this.pagedInput).subscribe(res=>{
				this.bgRows = res.data;
			}, 
					err=>{
						this.commonService.showError("Error occured while getting Bill Group Master");
					}, 
					()=>{});

	}  
	getList(evt, typeid){
		var obj ={parentId:evt, typeId:typeid};
		this.dataService.getPlaceList(obj).subscribe(res=>{
				this.divisions = res;
			}, 
					err=>{
						this.commonService.showError("Error occured while getting Division");
					}, 
					()=>{});
	}
	edit(obj)
	{
		this.showDetailPanel=true;
		this.current = obj;
		this.selectedRowId = obj.id;
	}
	delete(obj)
	{
		this.selectedRowId = obj.id;
	    this.dataService.deleteBGM(obj).subscribe(res=>{
			let  result = 	JSON.parse(res);
	 		 if (result.msg=="Success")
	          {  
                this.commonService.showSuccess("Bill Group Deleted Successfully")  ;
	            // this.alertType="success";
	            //   this.alertMessage="Data Saved Successfully";
	          }else
	          {
                this.commonService.showError(result.msg) ; 
	            // this.alertType="danger";
	            //   this.alertMessage="Not Saved Successfully, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.showDetailPanel=false;

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 

	}
	addNew()
	{
		var data = {id:0, code:'', description :'', startDay:1, biMonthy:false, biMonthlyEven:false, dueDays:15, divisionId:this.selectedDivision};
		this.current = data;
		this.showDetailPanel=true;
	}
	save()
	{
	    this.dataService.updateBGM(this.current).subscribe(res=>{
			let  result = 	JSON.parse(res);
	 		 if (result.msg=="Success")
	          {  
                this.commonService.showSuccess("Bill Group Updated  Successfully")  ;
	            // this.alertType="success";
	            //   this.alertMessage="Data Saved Successfully";
	          }else
	          {
                this.commonService.showError("Not Updated ") ; 
	            // this.alertType="danger";
	            //   this.alertMessage="Not Saved Successfully, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.showDetailPanel=false;

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 

	}
}
