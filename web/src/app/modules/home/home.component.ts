import { Component, OnInit } from '@angular/core';
import { RouterModule, Router} from '@angular/router';
import { CommonService } from '../shared/common.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
	menuItems=[];
    appMenu=[];
  adminMenu=[];
  constructor(private router:Router,  private commonService:CommonService) { }

  ngOnInit() {

  	      this.menuItems = JSON.parse(this.commonService.getValueFromStore("menuItems"));
          this.parseMenuItems();

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

    private parseMenuItems()
   {
     this.appMenu.length=0;
     this.adminMenu.length=0;
     if (this.menuItems!= undefined && this.menuItems.length >0)
     {
       for (var i = 0; i < this.menuItems.length; ++i) {
           let item = this.menuItems[i];
           if (item.parent=='apps')
             this.appMenu.push(item);
           if (item.parent=='admin')
             this.adminMenu.push(item);
       }
     }
   }

}
