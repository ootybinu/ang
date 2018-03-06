import { Component, OnInit } from '@angular/core';
import { RouterModule, Router} from '@angular/router';
import { TableHelperComponent } from '../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../common/tools/title/title.component';
import { PagedData} from '../../models/common/pageddata';
import { PagedResponse} from '../../models/common/pagedresponse';
import { PaginationComponent } from '../common/tools/pagination/pagination.component'; 
import { DashboardService } from '../shared/dashboard.service';
import { CommonService } from '../shared/common.service';
import { consumptionInput } from '../../models/dashboard/dashboard';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
 user;
 consumptionData;
 consumptionData2;
 divisionWiseData;
 oemData;
 messageData;
 graphtype:string='area';
 divisongraphtype:string='pie';
 oemgraphtype:string='verticalbar';
 filter1;
 filter2;
 filterInput:consumptionInput;
   menuItems=[];
    appMenu=[];
    loaded=false;
  constructor(private dataService:DashboardService, private commonService:CommonService,private router:Router) { }

  ngOnInit() {
  	this.user = this.commonService.getCurrentUser();
    let da = new Date();
    let da1 = new Date();
    da1.setMonth(da1.getMonth()-6);
    let m1 = da.getMonth()+1;
    let m2 = da1.getMonth()+1;
    let m3 = m1 >= 10 ?''+m1:'0' + m1;
    let m4 = m2 >= 10 ?''+m2:'0' + m2;

    this.filter2 = da.getFullYear() + '-' + m3;
    this.filter1 = da1.getFullYear() + '-' + m4;
    this.menuItems = JSON.parse(this.commonService.getValueFromStore("menuItems"));
    this.parseMenuItems();
  	this.getConsumptionData();
    this.getDivisionWise();
    this.getOemWise();
    this.getMessageData();
  }

  filter()
  {
    this.loaded=false;
    this.getConsumptionData();
    this.getDivisionWise();
  }
  viewpage(path:string)
  {
    if (path!= undefined)
      {
        let p=[];
        p.push(path); 
        //p[0] = path;
        this.router.navigate(p);
      }
  }
  private getConsumptionData()
  {
      this.filterInput= new consumptionInput();
      this.filterInput.from = this.filter1;
      this.filterInput.to =  this.filter2;
      this.filterInput.userId = this.user.employeeId;

  			this.dataService.getConsumptionData (this.filterInput).subscribe(res=> {
				this.consumptionData = res.data;
				this.consumptionData2 = res.alternateData;
        this.loaded=true;

		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);
      this.loaded=true;	
			}, 
		()=>{ });

  }

  private getDivisionWise()
  {
      let filterInput= new consumptionInput();
      filterInput.from = this.filter1;
      filterInput.to =  this.filter2;
      filterInput.userId = this.user.employeeId;

        this.dataService.getDivisionWise (filterInput).subscribe(res=> {
        this.divisionWiseData = res;
 
    }, 
    err=> {
      console.log('Error occured '+ err);
      this.commonService.showError(err);  
      }, 
    ()=>{ });

  }

  private getOemWise()
  {
      let filterInput= new consumptionInput();
      filterInput.from = this.filter1;
      filterInput.to =  this.filter2;
      filterInput.userId = this.user.employeeId;

        this.dataService.getOemWise(filterInput).subscribe(res=> {
        this.oemData = res;
 
    }, 
    err=> {
      console.log('Error occured '+ err);
      this.commonService.showError(err);  
      }, 
    ()=>{ });

  }
    private getMessageData()
  {
      let filterInput= new consumptionInput();
      filterInput.from = this.filter1;
      filterInput.to =  this.filter2;
      filterInput.userId = this.user.employeeId;

        this.dataService.getMessageData(filterInput).subscribe(res=> {
        this.messageData = res;
 
    }, 
    err=> {
      console.log('Error occured '+ err);
      this.commonService.showError(err);  
      }, 
    ()=>{ });

  }
      private parseMenuItems()
   {
     this.appMenu.length=0;
     // this.adminMenu.length=0;
     if (this.menuItems!= undefined && this.menuItems.length >0)
     {
       for (var i = 0; i < this.menuItems.length; ++i) {
           let item = this.menuItems[i];
           if (item.parent=='apps')
             this.appMenu.push(item);
           // if (item.parent=='admin')
           //   this.adminMenu.push(item);
       }
     }
   }
}
