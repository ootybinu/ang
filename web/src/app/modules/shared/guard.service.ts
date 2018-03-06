import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad } from '@angular/router';
import { Route,Router,ActivatedRouteSnapshot } from '@angular/router';

@Injectable()
export class GuardService implements CanActivate , CanActivateChild, CanLoad {

	canActivate(route:ActivatedRouteSnapshot)
	{
			//return this.check();
					let res =  this.check();
		if (route.parent != null && route.parent.url != null )
		{


		let newpage = '/' + route.parent.url[0].path + '/' + route.routeConfig.path;
		if (res==false)
		{
			this.router.navigate(['/login']);	
		}
		// let screens =  JSON.parse( sessionStorage.getItem("menuItems"));
		// for (var i = 0; i < screens.length; ++i) {
		// 	let menu = screens[i].path;
		// 	if (menu== newpage)
		// 		return true;
		// }
		let menuTree = JSON.parse(sessionStorage.getItem("menuTree"));
		let result = this.filterMenuTree(menuTree.subMenu, newpage);
		if (result==4) return true;

		this.router.navigate(['/missing', {msg :"Access restricted"} ]);
		return res;}
		return res;
	}
	canActivateChild()
	{
		return this.check();
	}

	canLoad(route:Route)
	{

		let res =  this.check();
		let newpage = '/' + route.path;
		var found=false;
		if (res==false)
		{
			this.router.navigate(['/login']);	
		}
		let menuTree = JSON.parse(sessionStorage.getItem("menuTree"));
		let result = this.filterMenuTree(menuTree.subMenu, newpage);
		if (result==4) return true;

	
		
		// let screens =  JSON.parse( sessionStorage.getItem("menuItems"));
		// for (var i = 0; i < screens.length; ++i) {
		// 	let menu = screens[i].path;
		// 	if (menu== newpage)
		// 		return true;
		// }
		this.router.navigate(['/missing', {msg :"Access restricted"} ]);

		// if (route.path.indexOf("admin/") >= 0 )
		// {
		// 	let user = JSON.parse( sessionStorage.getItem("user"));
		// 	if (user != undefined)
		// 	{
		// 		if (user.roleId=="0")
		// 			return true;
		// 		else 
		// 			this.router.navigate(['/missing', {msg :"Access restricted"} ]);
		// 	}
		// 	else
		// 	{
		// 			this.router.navigate(['/missing', {msg :"Access restricted"} ]);
		// 	}
		// }
		return res;
	}

	private filterMenuTree(mt, page)
	{

		for (var i = mt.length - 1; i >= 0; i--) {
			if (mt[i].menu.url == page){
				return mt[i].privilege & 4; // read access
			}
			var r=  this.filterMenuTree(mt[i].subMenu, page);
			if (r != undefined)
				return r;
		}

	}

	private check():boolean
	{
		let key=  sessionStorage.getItem("key");
		if (key == undefined || key == null || key.length ==0)
			return false;
		else
			return true;

	}

  constructor(private router:Router) { }

}
