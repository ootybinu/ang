import { Component, OnInit, Input, Output , EventEmitter} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UnitreportService } from '../../shared/unitreport.service';
import { CommonService} from '../../shared/common.service';

import {KeyValue}  from '../../../models/common/common';
import { GenericRequest } from '../../../models/GenericRequest' ;
import {searchList, subitem,searchResult}  from '../../../models/unitreport/searchList';

@Component({
  selector: 'app-unitreport-search',
  templateUrl: './unitreport-search.component.html',
  styleUrls: ['./unitreport-search.component.scss']
})
export class UnitreportSearchComponent implements OnInit {

	@Output() onSelected = new EventEmitter<searchResult>();
	@Output() onSwitch = new EventEmitter<boolean>();

    searchListdata:searchList = new searchList();
    selectedDivision:any;
    selectedSubDivision;
    selectedLocation;
    selectedService; 
    selectedConsumer;
    selectedMeter;
    selectedFromDate; 
    selectedToDate;

    subDivisions:KeyValue<number>[]=[];
    servicesList:KeyValue<number>[]=[];
    locationsList:KeyValue<number>[]=[];
    consumerList:KeyValue<number>[]=[];
	constructor(private dataService:UnitreportService, private commonService:CommonService) { }

	ngOnInit() {
		this.getInitialSearch();
  	}

  	divisionChange(evt)
  	{
  		let value = evt.target.value;
  		let input = new subitem();
  		input.parentId = parseInt(value);
  		input.typeId = 2;
  		this.subDivisions = undefined;

  		this.dataService.getSubList(input).subscribe(res=>{
  			this.subDivisions = res;
  		}, 
  		err=> {
        console.log('Error occured '+ err);
          this.commonService.showError(err);  
      }, 
		  ()=>{ });


  	}
  	subDivisionChange(evt)
  	{
  		let value = evt.target.value;
  		let input = new subitem();
  		input.parentId = parseInt(value);
  		input.typeId = 4;
  		this.servicesList = undefined;

  		this.dataService.getSubList(input).subscribe(res=>{
  			this.servicesList = res;
  		}, 
  		err=> {
        console.log('Error occured '+ err);
          this.commonService.showError(err);  
      }, 
		  ()=>{ });


  	}

  	serviceChange(evt)
  	{
  		let value = evt.target.value;
  		let input = new subitem();
  		input.parentId = parseInt(value);
  		input.typeId = 3;
  		this.locationsList = undefined;

  		this.dataService.getSubList(input).subscribe(res=>{
  			this.locationsList = res;
  		}, 
  		err=> {
        console.log('Error occured '+ err);
        this.commonService.showError(err);  
        }, 
		    ()=>{ });

		var input2 = new subitem();
		input2.parentId = parseInt(value);
  		input2.typeId = -1;
  		this.consumerList = undefined;
  		this.dataService.getSubList(input2).subscribe(res=>{
  			this.consumerList = res;
  		}, 
  		err=> {
              console.log('Error occured '+ err);
              this.commonService.showError(err);  
    }, 
		()=>{ });



  	}

  	searchClicked()
  	{
  		let obj= new searchResult();
  		obj.division = this.selectedDivision;
  		obj.subDivision = this.selectedSubDivision; 
  		obj.service = this.selectedService; 
  		obj.location = this.selectedLocation;
  		obj.consumer = this.selectedConsumer;
  		obj.meterType = this.selectedMeter;
  		obj.oEM = this.selectedOEM;
      obj.fromDate= this.selectedFromDate;
      obj.toDate= this.selectedToDate;

  		this.onSelected.emit(obj);
  	}
  	hidePanel()
  	{
  		this.onSwitch.emit(false);
  	}
	private getInitialSearch(){
		let user = this.commonService.getCurrentUser();
    let gr = new GenericRequest();
    gr.UserId = user.employeeId;
    gr.RoleId = user.roleId;
    gr.OEM = user.oem;
    gr.Designation=user.designation;

		this.dataService.getInitialSearchLists(gr).subscribe(res=> {
			this.searchListdata.Divisions = res.divisions;
			this.searchListdata.OEM = res.oeMs;
			this.searchListdata.Meter = res.meterTypes;
		}, 
		err=> {
      console.log('Error occured '+ err);
      this.commonService.showError(err);  
    }, 
		()=>{ });

  	}

}
