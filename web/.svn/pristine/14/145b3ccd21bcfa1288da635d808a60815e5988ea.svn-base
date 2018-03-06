import { Component, OnInit } from '@angular/core';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../../shared/common.service';
 import { Role, SearchParam, RoleResponse} from '../../../models/role/role';
import { RoleService } from '../../shared/role.service';
import { TableHelperComponent } from '../../common/tools/table-helper/table-helper.component';
import { TitleComponent } from '../../common/tools/title/title.component';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent implements OnInit {
	showDetailPanel:boolean = false;
  	addNew:boolean = false;
  	current:Role;
  	result:RoleResponse;
    menuTree;
  	pagedInput:PagedData<SearchParam> = new PagedData<SearchParam>();
	totalpages:number=10;
    roleRows=[];
    alertMessage:string="";
    alertType;
    selectedRowId;
  constructor(private dataService:RoleService, private commonService:CommonService ) { }

  ngOnInit() {
      this.pagedInput.PageNumber = 1;
      this.pagedInput.NumberOfRecords=10;
      this.pagedInput.Data = new Role();
      this.getData();
  }

  move(src:string, item:any)
  {
  	let source:any;
  	let target:any;

  	switch (src) {
  		case "app":
  			source = this.result.appMenu;
  			target = this.result.appMenuRestricted;
  			break;
  		case "appR":
  			source = this.result.appMenuRestricted;
  			target = this.result.appMenu;	
  			break;
  		case "admin":
  			source = this.result.adminMenu;
  			target = this.result.adminMenuRestricted;
  			break;
  		case "adminR":
  			source = this.result.adminMenuRestricted;
  			target = this.result.adminMenu;	
  			break;  		
  		default:
  			// code...
  			break;
  	}
  	let index = source.indexOf(item);
  	let tmp = source.splice(index,1);
  	target.push(tmp[0]);
  	  // 			let index = this.result.appMenu.indexOf(item);
  			// let tmp = this.result.appMenu.splice(index,1);
  			// this.result.appMenuRestricted.push(tmp[0]);

  }
    showDetail_click(value:boolean)  {
  	if (value){
		      this.dataService.getDetail(-1).subscribe(res=>{
		      		  	this.current = new Role();
	  	this.current.roleid=0;
      	this.addNew = true;
//		          this.current = new Role();
		          this.result = new RoleResponse();
		          // this.result.appMenu = res.appMenu;
		          // this.result.adminMenu = res.adminMenu;
		          // this.result.appMenuRestricted = res.appMenuRestricted;
		          // this.result.adminMenuRestricted = res.adminMenuRestricted;	
				 this.showDetailPanel = value;
		      }, err=>{
		          console.log('Error occured '+ err);
		          this.commonService.showError(err);

		      } ,()=>{

		      }); 

      	}else{
	  	this.showDetailPanel = value;}
	}

getDetail(id)
  {
    this.selectedRowId = id;
      this.dataService.getDetail(id).subscribe(res=>{
          this.current = res.role;
          this.result = new RoleResponse();
          this.menuTree =  JSON.parse(this.commonService.getValueFromStore("menuTree"));
          this.result.privileges = res.privileges;

           this.updateMenuTree(this.menuTree.subMenu, res.privileges);
           this.result.menuTree = this.menuTree;
           console.log(this.result.menuTree);
          // this.result.appMenu = res.appMenu;
          // this.result.adminMenu = res.adminMenu;
          // this.result.appMenuRestricted = res.appMenuRestricted;
          // this.result.adminMenuRestricted = res.adminMenuRestricted;	

          this.showDetailPanel = true;
          this.addNew= false;

      }, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      } ,()=>{

      });  
  	}
  pageChanged(nextPage:number){
    this.pagedInput.PageNumber=nextPage;
    this.getData();
  }
  private updateMenuTree(mt, pr)
  {
    for (var i = mt.length - 1; i >= 0; i--) {
      let ob = pr.filter(function (ob){return ob.menuid==mt[i].menu.id});
      let val =  (ob==undefined || ob == null || ob.length==0) ?0 :ob[0].allowedto;
      mt[i].privilege = val;
      //mt[i].privilege = pr.filter(function (ob){return ob.menuid==mt[i].menu.id})[0].allowedto;
      mt[i].view= (mt[i].privilege & 4)==4;
      this.updateMenuTree(mt[i].subMenu, pr);

    }
  }
  private updatePrivilege(mt)
  {
    for (var i = mt.length - 1; i >= 0; i--) {
//      let ob = pr.filter(function (ob){return ob.menuid==mt[i].menu.id});
      if  (mt[i].view)  
      {
        if (mt[i].privilege ==0 || mt[i].privilege & 4 != 4)
          mt[i].privilege += 4; 
      } 
      else 
      {
        if (mt[i].privilege & 4 == 4)
          mt[i].privilege -= 4;

      }
      this.updatePrivilege(mt[i].subMenu);

    }
  }
  save()
  {
  	this.result.role = this.current;
    if (this.result.menuTree != undefined && this.result.menuTree != null)
          this.updatePrivilege(this.result.menuTree.subMenu);
    this.dataService.update(this.result).subscribe(
	      res=>{
	        if (res)
	          {  
              this.commonService.showSuccess("Success", "Role Saved Successfully.");
	            // this.alertType="success";
	            //   this.alertMessage="Role Saved Successfully";
	          }else
	          {
                            this.commonService.showError( "Role Not Saved Successfully.");

	            // this.alertType="danger";
	            //   this.alertMessage="Roles not updated Successfully, Check Logs";
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
  private getData()    {
    this.dataService.getAll(this.pagedInput).subscribe(res=>{
    	this.roleRows = res.data;
	    this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
      	}, err=>{
          console.log('Error occured '+ err);
          this.commonService.showError(err);

      	} ,()=>{

      	}); 
    }

}
