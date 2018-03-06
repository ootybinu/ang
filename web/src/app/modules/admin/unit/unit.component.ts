import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
import { Unit, SelectionLists, subitem , UnitSearch} from '../../../models/unit/unit';
import { UnitSummaryService } from '../../shared/unitsummary.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';


@Component({
  selector: 'app-unit',
  templateUrl: './unit.component.html',
  styleUrls: ['./unit.component.scss']
})
export class UnitComponent implements OnInit {
	showDetailPanel:boolean = false;
  addnew:boolean = false;
  	currentUnit:Unit;
  	selectionLists :SelectionLists;
    unitSearch:UnitSearch;
    pagedInput:PagedData<UnitSearch> = new PagedData<UnitSearch>();
	  totalpages:number=10;
    unitSummaryRows=[];
    alertMessage:string="";
    alertType;
    selectedRowId;
	constructor(private dataService:UnitSummaryService, private commonService:CommonService ) { }

  ngOnInit() {

      this.pagedInput.PageNumber = 1;
      this.pagedInput.NumberOfRecords=20;
      this.pagedInput.Data = new UnitSearch();

  		this.getInitialData();
      this.getData();
  }
  
  showDetail_click(value:boolean)  {
	  	if (value){
	  		// if(this.currentUnit == undefined || this.currentUnit== null)
     //    {
	  			this.currentUnit = new Unit();
          this.currentUnit.daysofwaterflow="False,False,False,False,False,False,False";
        //}
      this.addnew = true;
      }
	  	this.showDetailPanel = value;
	}
  
  save()  {
    this.dataService.update(this.currentUnit).subscribe(
      res=>{
        if (res)
          {  
            this.commonService.showSuccess("Unit Saved Successfully") ;
            // this.alertType="success";
            //   this.alertMessage="Unit Saved Successfully";
          }else
          {
            this.commonService.showError("Unit Not Saved") ;
            // this.alertType="danger";
            //   this.alertMessage="Unit not Saved Successfully, Check Logs";
          }

          // setTimeout(function (){
          // //#exceptionDiv.hide();
          // this.alertMessage=null;
          // }.bind(this),1000*5);
          this.getData();
          this.showDetailPanel=false;
        }, 
      err=> {
        console.log('error occured ' + err);
        this.commonService.showError(err);  
      }, 
      ()=>{console.log('Completed getting search data');}
      );
  }

  dayClick(value:number)  {
    let valuechange = document.getElementsByName("item"+value)[0].checked ?"True":"False";
    let tem = this.currentUnit.daysofwaterflow.split(",");
    tem[value] = valuechange;
    this.currentUnit.daysofwaterflow = tem.join(",");
    console.log(this.currentUnit.daysofwaterflow);
  }
  placeChange(evt, typeid:number)  {
      let value = evt.target.value;
      let input = new subitem();
      input.parentId = parseInt(value);
      input.typeId = typeid;
 
      this.dataService.getSubList(input).subscribe(res=>{
        if (typeid==2){
          this.selectionLists.SubDivisions= res;
          this.selectionLists.ServiceStations = undefined;
          this.selectionLists.Locations = undefined;
        }
        if (typeid==4){
            this.selectionLists.ServiceStations = res;
            this.selectionLists.Locations = undefined;

          }
        if (typeid ==3){
            this.selectionLists.Locations = res;
          }
      }, 
      err=> {
        console.log('Error occured '+ err);
          this.commonService.showError(err);  
      }, 
      ()=>{ });
  }

  pageChanged(nextPage:number){
    this.pagedInput.PageNumber=nextPage;
    this.getData();
  }

  getDetail(id)
  {
    this.selectedRowId = id;
      this.dataService.getDetail(id).subscribe(res=>{
          this.currentUnit = new Unit();
          this.selectionLists.WeekNames = this.commonService.getWeekNames();
          this.selectionLists.SubDivisions= res.subDivisions;
          this.selectionLists.ServiceStations = res.serviceStations;
          this.selectionLists.Locations = res.locations;
          //this.selectionLists.BillGroups = res.billGroups;
          this.currentUnit =  res.data;
          if (this.currentUnit.installon != null && this.currentUnit.installon != undefined )
            this.currentUnit.installon = this.currentUnit.installon.slice(0,10);
          if (this.currentUnit.rechargedate != null && this.currentUnit.rechargedate != undefined )
            this.currentUnit.rechargedate = this.currentUnit.rechargedate.slice(0,10);
          if (this.currentUnit.metercalibrationdate != null && this.currentUnit.metercalibrationdate != undefined )
            this.currentUnit.metercalibrationdate = this.currentUnit.metercalibrationdate.slice(0,10);
          this.showDetailPanel = true;
          this.addnew= false;

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      });  
  }
  private getInitialData()  	{
  		this.dataService.getInitialLists ()
  		.subscribe(res => {
  			this.selectionLists = new SelectionLists();
  			this.selectionLists.OEMNames = res.oemNames;
  			this.selectionLists.MeterTypes = res.meterTypes;
  			this.selectionLists.FlowTypes = res.flowTypes;
  			this.selectionLists.MeterBillingTypes = res.meterBillingTypes;
  			this.selectionLists.MobileServiceProviders = res.mobileServiceProviders;
  			//this.selectionLists.WeekNames = res.weekNames;
        this.selectionLists.BillGroups = res.billGroups;
        this.selectionLists.WeekNames = this.commonService.getWeekNames();

  			this.selectionLists.CommModes = res.commModes;
  			this.selectionLists.DivisionHeads = res.divisionHeads;
  			this.selectionLists.SubDivisionHeads = res.subDivisionHeads;
  			this.selectionLists.ConsumerNames = res.consumerNames;
  			this.selectionLists.Divisions = res.divisions;
  		}, 
  		err=> {
  			console.log('error occured ' + err);
  			this.commonService.showError(err);	
  		}, 
  		()=>{console.log('Completed getting search data');}
  		);
  	}

   private getData()    {
      this.dataService.getAll(this.pagedInput).subscribe(res=>{
          this.unitSummaryRows = res.data;
          this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      }); 
    }

}
