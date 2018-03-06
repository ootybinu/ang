import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';

import { OrganizationService } from '../../shared/organization.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import { orginput,orgShort } from '../../../models/organization/organization';
import { User } from '../../../models/common/user';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.scss']
})
export class OrganizationComponent implements OnInit {
	org1 = new Array();
	org2 = new Array();
	org3 = new Array();
	org4 = new Array();
	showEditor:boolean=false;
	currentItem:orgShort;
	orgHeader:string="";
	orgAddHeader:string="";
	alertMessage:string="";
    alertType;
    parent1?:number; 
    parent2?:number;
    parent3?:number;
	newItem:orgShort;
	username:string ; 
	addNew:boolean=false;

  constructor(private dataService:OrganizationService , private commonService:CommonService) { }

	ngOnInit() {

	this.username= this.commonService.getObjectFromStore<User>("user").loginName;
			let input = new orginput();
			this.getData(input, this.org1);
	}
	
	getMembers(item:orgShort, container, index:number){
		let arr = new Array();
		switch (index) {
			case 1:
				this.parent1 = item.organizationid;
				arr = [this.org2, this.org3, this.org4];
				this.clear(arr);
				break;
			case 2:
				this.parent2 = item.organizationid;
				arr = [this.org3, this.org4];
				this.clear(arr);
				break;
			case 3:
				this.parent3 = item.organizationid;
				arr = [this.org4];
				this.clear(arr)	;
				break;
			default:
				// code...
				break;
		}
		let input = new orginput();
		input.parentid = item.organizationid ;
		this.getData(input, container);
	}

	add(index:number, header:string)
	{
		this.orgAddHeader = header;
		this.newItem = new orgShort();
		this.newItem.createdby = this.username;
		this.newItem.organizationtypeid = index;
		this.addNew = true;

		switch (index) {
			case 1:
				this.newItem.parentid = null;
				break;
			case 2:
				this.newItem.parentid = this.parent1;
				break;
			case 3:
				this.newItem.parentid = this.parent3;
				break;
			case 4:
				this.newItem.parentid = this.parent2;
				break;
			default:
				// code...
				break;
		}

		

	}
	addOrg()
	{
		this.dataService.add(this.newItem).subscribe(res=>{
			let  result = 	JSON.parse(res);
   		  	if (result.msg=="Success")
	          {  
	          	this.commonService.showSuccess("Data Saved Successfully");
	            // this.alertType="success";
	            //   this.alertMessage="Data Saved Successfully";
	          }else
	          {
	          		this.commonService.showError("Not Saved");
	            // this.alertType="danger";
	            //   this.alertMessage="Not Saved Successfully, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.addNew=false;
	          this.refresh(this.newItem);
	   //      	let input = new orginput();
				// this.getData(input, this.org1);

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
	}
	refresh(item)
	{
		let input = new orginput();
		let container;
		input.parentid = item.parentid ;
		switch (item.organizationtypeid){
			case 1:
				container = this.org1;
			break;
			case 2:
				container = this.org2;
			break;
			case 3:
				container = this.org4;
			break;
			case 4:
				container = this.org3;
			break;

		}
		this.getData(input, container);

	}
   	edit(header, item)
   	{
   		this.showEditor=true;
   		this.orgHeader=header;
   		this.currentItem = item;
   		this.currentItem.createdby = this.username;// this.commonService.getObjectFromStore<User>("user").loginName;

   	}
   	delete(item){
   		let ans = confirm("Are you sure ?");
   		if (ans)
   		{
   			this.dataService.delete(item).subscribe(res=>{
			let  result = 	JSON.parse(res);
   		  	if (result.msg=="Success")

	          {
	          this.commonService.showSuccess("Data Updated Successfully")  ;
	          }else
	          {
	          	this.commonService.showError(result.msg);
	          }

	          this.showEditor=false;
	          this.refresh(item);
      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
   		}
   	}
   	updateOrg()
   	{
   		      this.dataService.update(this.currentItem).subscribe(res=>{
   		      let  result = 	JSON.parse(res);
   		  		if (result.msg=="Success")
	          {  
	          	  this.commonService.showSuccess("Data Updated Successfully")  ;
	            // this.alertType="success";
	            //   this.alertMessage="Data Updated Successfully";
	          }else
	          {
	          		this.commonService.showError(result.msg);
	            // this.alertType="danger";
	            //   this.alertMessage="Not updated Successfully, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.showEditor=false;
	          this.refresh(this.currentItem);
	   //      	let input = new orginput();
				// this.getData(input, this.org1);

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 

   	}
   	private clear(arr)
   	{
   		for (var i = 0; i < arr.length; ++i) {
			let item = arr[i];
			item.length=0;
   			// for (var j = 0; j < item.length; ++j) {
   			// 		item.pop();
   			// }
		}		
   	}
   	
   	private getData(input, container)    {
      this.dataService.getOrgMembers (input).subscribe(res=>{
      	container.splice(0,container.length);
      		// for (var i = 0; i < container.length; ++i) {
      		// 	container.pop();
      		// }
      		for (var i = 0; i < res.length; ++i) {
      			container.push(res[i]);
      		}
      		console.log(this.org1);
      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
    }
}
