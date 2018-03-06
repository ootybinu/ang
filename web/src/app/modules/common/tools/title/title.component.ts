import { Component, OnInit, Input} from '@angular/core';
import { RouterModule, Router } from '@angular/router';
import { CommonService } from '../../../shared/common.service';
@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {

  constructor(private router:Router,   private commonService:CommonService) { }
  @Input() title:string;
  imagePath:string;
  ngOnInit() {
let currentpath="";
  	// let currentPaths =  this.router.url.split("/");
  	// if (currentPaths[1]=='admin' || currentPaths[1]=='billing')
  	// 	currentpath = "/"+currentPaths[1]+"/" +currentPaths[2];
  	// else 
  	// 	currentpath = "/"+currentPaths[1];

    let menuTree = JSON.parse(sessionStorage.getItem("menuTree"));
//    let menu = this.GetMenu(menuTree.subMenu, currentpath);
    let path = this.router.url;
    if (path.substr(0,17)=='/realtime/history')
      path = '/realtime';

    let menu = this.GetMenu(menuTree.subMenu, path);
    if (menu != undefined && menu != null)
    {
        this.imagePath = menu.menu.iconPath;
    }

 //  	let screens =  JSON.parse( sessionStorage.getItem("menuItems"));
	
	// for (var i = 0; i < screens.length; ++i) {
	// 		let menu = screens[i].path;
	// 		if (menu== currentpath)
	// 		{
	// 			this.imagePath= screens[i].icon;
	// 			break;
	// 		}
	// 	}
  }

  private GetMenu(mt, url )
  {
    let ctr=0;
    let i = mt.length;
    while (ctr<i)
    {
      if (mt[ctr].menu.url == url) 
          return mt[ctr];

        let obj = this.GetMenu(mt[ctr].subMenu, url);
        if (obj != undefined)
          return obj;
        ctr++;
    }
  }


}
