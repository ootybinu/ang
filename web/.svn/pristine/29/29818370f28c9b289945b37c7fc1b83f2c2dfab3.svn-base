import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
import { UserService } from '../../shared/user.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { userrow, userFull,employee,empMeta} from '../../../models/user/user';
import { User } from '../../../models/common/user';
import {KeyValuePair} from '../../../models/common/common';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {
	showDetailPanel:boolean = false;
	showPasswordPanel :boolean=false;
	addNew:boolean = false;
	currentUser:userFull;
  	totalpages:number=10;
  	userRows=[];
  	roleList:KeyValuePair<number>;
    divisionList:KeyValuePair<number>;
    subDivisionList:KeyValuePair<number>;
	pagedInput:PagedData<userrow> = new PagedData<userrow>();
	alertMessage:string="";
    alertType;
    confirmpassword:string;
    isAdmin:boolean;
    pd_loginname:string;
    pd_password1:string;
    pd_password2:string;
    pd_id;
    prevSort:string="loginname";
    sortByAsc:boolean=true;
    sortColumn:string="loginname";
    selectedRowId;
  	constructor(private dataService:UserService , private commonService:CommonService ) { }

  ngOnInit() {
  	this.pagedInput.PageNumber = 1;
    this.pagedInput.NumberOfRecords=10;

    this.isAdmin=    this.commonService.getObjectFromStore<User>("user").roleId ==0;

    //this.pagedInput.Data 
    this.getData();
  }

  pageChanged(nextPage:number){
    this.pagedInput.PageNumber=nextPage;
    this.getData();
  }
  showPassword(id, loginname)
  {
  	this.pd_id=id;
  	this.pd_loginname=loginname;
  	this.showPasswordPanel=true;

  }
    sort(sortby:string)
  {
    if (sortby == this.prevSort)
      this.sortByAsc = ! this.sortByAsc;

    this.pagedInput.SortBy = sortby;
    this.pagedInput.SortAsc = this.sortByAsc;  
    this.prevSort = sortby;
    this.getData();


  }
  changePassword()
  {
  	if (this.pd_password1 != this.pd_password2)
  		alert("passwords do not match");
  	else 
  	{
  			    this.dataService.updatePassword({Key:this.pd_loginname, Value:this.pd_password1} ).subscribe(
	      res=>{
	        if (res)
	          {  
                this.commonService.showSuccess("Password Changed Successfully") ;
	            // this.alertType="success";
	            //   this.alertMessage="Password  Changed  Successfully";
	          }else
	          {
                this.commonService.showError("Password Not Changed")  ;
	            // this.alertType="danger";
	            //   this.alertMessage="Password not changed, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.showPasswordPanel=false;
	        }, 
	      err=> {
	        console.log('error occured ' + err);
	        this.commonService.showError(err);  
	      }, 
	      ()=>{console.log('Completed getting search data');}
	      );

  	}

  }
  showDetail_click(value:boolean)  {
  	if (value){
  		if (this.roleList == undefined)
  		{
  			this.dataService.getRoles().subscribe(res =>{
  					this.roleList = res;
  			}, err=> {
	        console.log('error occured ' + err);
	        this.commonService.showError(err);  
	      }, 
	      ()=>{console.log('Completed getting search data');}
	      );

  		}

      if (this.divisionList == undefined || this.divisionList == null)
      {
        this.dataService.getOrganization().subscribe (res=>{
          this.divisionList = res;

        }, err=>{}, ()=>{});
      }
      //this.divisionList

	  	this.currentUser = new userFull();
	  	this.currentUser.emp = new employee();
	  	this.currentUser.emplog = new empMeta();
      	this.addNew = true;
      	}
	  	this.showDetailPanel = value;
	}
 save()  {
 	let proceed = true;
 	if (this.addNew){
 		if (this.currentUser.emplog.password != this.confirmpassword  )
 		{
 			alert("passwords do not match");
 			proceed=false;

 		}

 	}
 	if (proceed){
	    this.dataService.update(this.currentUser).subscribe(
	      res=>{
	        if (res)
	          {  
                this.commonService.showSuccess("User Saved Successfully") ; 
	            // this.alertType="success";
	            //   this.alertMessage="User Saved Successfully";
	          }else
	          {
                this.commonService.showError("User Not Saved")  ;
	            // this.alertType="danger";
	            //   this.alertMessage="User not Saved Successfully, Check Logs";
	          }

	          // setTimeout(function (){
	          // //#exceptionDiv.hide();
	          // this.alertMessage=null;
	          // }.bind(this),1000*5);
	          this.showDetailPanel=false;
            this.getData();
	        }, 
	      err=> {
	        console.log('error occured ' + err);
	        this.commonService.showError(err);  
	      }, 
	      ()=>{console.log('Completed getting search data');}
	      );
		}
  }
  getDetail(id)
  {
    this.selectedRowId = id;
      this.dataService.getDetail(id).subscribe(res=>{
          this.currentUser = new userFull();
          this.currentUser.emp = new employee();
	  	  this.currentUser.emplog = new empMeta();
          this.currentUser.emp = res.data.emp;
          this.currentUser.emplog = res.data.emplog;
          this.roleList = res.roles;
          this.divisionList = res.divisions;
          this.subDivisionList = res.subDivisions;

          this.showDetailPanel = true;
          this.addNew= false;

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      });  
  	}
  placeChange(selected, typeid)
  {
    this.getList(selected.target.value, typeid);
  }
  getList(evt, typeid){
var obj ={parentId:evt, typeId:typeid};
if (evt != ""){
      this.dataService.getPlaceList(obj).subscribe(res=>{
        this.subDivisionList = res;
        }, 
          err=>{
            this.commonService.showSuccess("Error occured while generating Bills ","Exception");
          }, 
          ()=>{});

  }
}
   private getData()    {
      this.dataService.getAllUsers(this.pagedInput).subscribe(res=>{
          this.userRows = res.data;
          this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
    }


}
