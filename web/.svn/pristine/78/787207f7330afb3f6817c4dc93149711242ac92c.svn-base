import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
import { OemService } from '../../shared/oem.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { oeminput, oem } from '../../../models/oem/oem';
import { User } from '../../../models/common/user';


@Component({
  selector: 'app-oem',
  templateUrl: './oem.component.html',
  styleUrls: ['./oem.component.scss']
})
export class OemComponent implements OnInit {
	pagedInput:PagedData<oeminput> = new PagedData<oeminput>();
	oemRows=[];
	totalpages:number=10;
	showDetailPanel:boolean = false;
	addNew :boolean = false;
	currentOem:oem;
	userId;
	alertMessage:string="";
    alertType;
    selectedRowId;
  constructor(private dataService:OemService , private commonService:CommonService ) { }

  ngOnInit() {
  	  	this.pagedInput.PageNumber = 1;
    	this.pagedInput.NumberOfRecords=20;
    	this.userId= this.commonService.getObjectFromStore<User>("user").employeeId;
    	this.getData();
  }

  pageChanged(nextPage:number){
    this.pagedInput.PageNumber=nextPage;
    this.getData();
  }
  
  showDetail_click(value:boolean)  {
  	this.addNew	 = value;
  	if (this.addNew)
  		this.currentOem = new oem();
  	this.showDetailPanel = true;
  }
  edit(item)
  {
  	this.currentOem = item;
  	this.showDetailPanel = true;
  	this.addNew = false;
    this.selectedRowId = item.code;
  }
  save()
  {
  	this.currentOem.modifiedby = this.userId;
  	      this.dataService.save(this.currentOem).subscribe(res=>{
   		  if (res.result=="")
	          {  
                this.commonService.showSuccess("Data Saved Successfully")  ;
	            // this.alertType="success";
	            //   this.alertMessage="Data Saved Successfully";
	          }else
	          {
                this.commonService.showError("Not Saved ") ; 
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
   private getData()    {
      this.dataService.getAll(this.pagedInput).subscribe(res=>{
          this.oemRows = res.data;
          this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
    }
}
