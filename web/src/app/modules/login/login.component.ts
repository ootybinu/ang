import { Component, OnInit} from '@angular/core';
import { Router} from '@angular/router';
import { FormsModule} from '@angular/forms';
import { CommonService} from '../shared/common.service';
import { AuthenticateService } from '../shared/authenticate.service';
import { MessengerService } from '../shared/messenger.service';
import { KeyValuePair } from '../../models/common/common';
import { User } from '../../models/common/user';
import { menuitem } from '../../models/home/menuitem'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
	username:string;
	password:string;
	loggedIn :boolean = false;
  menuTree:{};
  menuitems=[];
  user;
  message:string;
  disableLogin:boolean=false;
  orgInfo;

  constructor(private service:AuthenticateService, private messenger:MessengerService,private router:Router,  private commonService:CommonService) { }

  ngOnInit() {
        let isthereuser = this.commonService.getValueFromStore("key");

    this.loggedIn= !( isthereuser== null || isthereuser =="" );
  }


  login()
  {
    this.disableLogin=true;
  		this.service.authenticateUser(this.username, this.password)
  		.subscribe(res=> {
        this.processLogin(res);
  		}, 
  			err=>{
          console.log(err);
          this.commonService.showError(err);
//          this.message=err;
          this.disableLogin=false;
        }, 
  			()=>{});


  }
  logout()
  {
    this.commonService.removeValueFromStore("key");
    this.commonService.removeValueFromStore("user");
     this.commonService.removeValueFromStore("orgInfo");
    this.commonService.removeValueFromStore("menuItems");
    this.router.navigate(['login']);
  }
  private processLogin(res)
  {
    if (res.message == null || res.message == "")
    {
      var self = this;
      this.menuitems=[];
    //   if (res.menuItems != null){
    //   for (var i = 0; i<res.menuItems.length; i++)
    //   {
    //     let ob = res.menuItems[i];
    //     let mi = new menuitem();
    //     mi.id = ob.menuId;
    //     mi.name=ob.menuName;
    //     mi.description=ob.menuDescription;
    //     mi.icon = ob.iconPath;
    //     mi.path = ob.containerURL;
    //     mi.parentid=ob.parentMenuId;
    //     mi.parent=ob.helpURL;
    //     mi.message=ob.staticMessage;
    //     mi.show = ob.showInMenu;
    //     this.menuitems.push (mi);
    //   }
    // }
      this.user = res.user;
      this.menuTree = res.menuTree;
      this.orgInfo = res.orgInfo;
     // this.commonService.putValueIntoStore("menuItems",JSON.stringify( this.menuitems));
      this.commonService.putValueIntoStore("menuTree",JSON.stringify( this.menuTree));
      this.commonService.putValueIntoStore("orgInfo", JSON.stringify(this.orgInfo));
      this.commonService.putValueIntoStore("key",res.tokenId);
      let kvp = new KeyValuePair<User>();
      kvp.key="loggedIn";
      kvp.value = this.user;
      this.messenger.publish(kvp);
//      this.loggedIn = true;
      if (this.user.landingPage != '')
      {
        let nav=[];
        nav[0] = (this.user.landingPage == undefined || this.user.landingPage == null) ? '/home' :  this.user.landingPage;
        this.router.navigate(nav);
      }else
      {
      this.router.navigate(['/home']);
      }
      // self.zone.run(        ()=>
      //   { this.router.navigate(['/home']);});
//      self.router.navigate(['/home']);
//      this.router.navigate(['home']);
    }
    else 
    {
      this.commonService.showError(res.message);
//        this.message = res.message;
        this.disableLogin=false;
    }
  }

}
