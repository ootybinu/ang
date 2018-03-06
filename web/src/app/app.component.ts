import { Component, TemplateRef , OnInit, OnDestroy,ViewContainerRef  } from '@angular/core';
import { RouterModule, Router, Event as RouterEvent, 
         NavigationStart, NavigationEnd, 
         NavigationCancel, NavigationError } from '@angular/router';
import { MessengerService } from './modules/shared/messenger.service';
import { CommonService } from './modules/shared/common.service';
import { KeyValuePair } from './models/common/common';
import { User } from './models/common/user';
import { MissingComponent } from './missing/missing.component';
import { ToastsManager, ToastOptions } from 'ng2-toastr/ng2-toastr'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  isLoggedin :boolean=false;
  isloading:boolean:false;
  exceptionMsg:string;
  title = 'Water AMR';
  menuTree={};
  //menuItems=[];
  appMenu=[];
  adminMenu=[];
  orgInfo;
  headerIcon:String="";
  private messageStream:any;
  // messege:KeyValuePair<User>;
  messege:any;
  user:User;
  showApps:boolean=false;
  headerText:string;
  subHeaderText:string;

  constructor(private router:Router, private messenger:MessengerService, private commonService:CommonService, 
    public toastr:ToastsManager, vcr:ViewContainerRef, private toastOptions:ToastOptions){
    this.toastOptions.positionClass = 'toast-bottom-right';
    this.toastr.setRootViewContainerRef(vcr);
      router.events.subscribe((event:RouterEvent ) =>{ 
          this.navigationIntercept(event);
      });
  }

  loggedIn(user:boolean){
  	this.isLoggedin=true;
  	this.router.navigate(['/home']);
  }

  ngOnInit(){

    let loggedin = this.commonService.getValueFromStore("key");

    this.isLoggedin= !( loggedin== null || loggedin =="" );
    this.user = this.commonService.getObjectFromStore<User>("user");
   // this.menuItems = JSON.parse(this.commonService.getValueFromStore("menuItems"));
    this.menuTree =  JSON.parse(this.commonService.getValueFromStore("menuTree"));
//    this.orgInfo  = JSON.parse(this.commonService.getValueFromStore("orgInfo"));
    //this.parseMenuItems();
    this.updateOrgInfo();
    this.messageStream = this.messenger.messenger.subscribe(t=>{
        this.messege = t;
        this.processMessage(); 
        
    });
    if (!this.isLoggedin)
        this.router.navigate(['/login']);
  }
  ngOnDestroy(){
    this.messageStream.unsubscribe();

  }
  toggleApps()
  {
    this.showApps = ! this.showApps;
  }
  viewpage(path:string)
  {
    let p=[]; 
    p.push( path);
    this.router.navigate(p);
    this.showApps = false;
  }
  gotoHome()
  {
    let p=[];
    if (this.isLoggedin)
    {
      if (this.user != undefined && this.user != null && this.user.landingPage != undefined && this.user.landingPage != null )
          p.push(this.user.landingPage);
      else 
          p.push('/home');
    }
    else 
      p.push('/home');
    this.router.navigate(p);
  }
  logout()
  {
//     this.commonService.removeValueFromStore("key");
//     this.commonService.removeValueFromStore("user");
//     this.commonService.removeValueFromStore("menuItems");
    
//   //  this.user.loginName="";
// //    this.user=undefined;
//     this.isLoggedin = false;
    this.clearLogin();
    this.router.navigate(['login']);
  }

  private clearLogin()
  {
    this.commonService.removeValueFromStore("key");
    this.commonService.removeValueFromStore("user");
    //this.commonService.removeValueFromStore("menuItems");
    this.commonService.removeValueFromStore("menuTree");
    this.commonService.LocalStore = null;
    this.isLoggedin = false;
  }
   private navigationIntercept(event:RouterEvent):void {
     if (event instanceof NavigationStart)
       { this.isloading = true;}
     if (event instanceof NavigationEnd || event instanceof NavigationError || event instanceof NavigationCancel)
       this.isloading = false;
   }

   // private parseMenuItems()
   // {
   //   this.appMenu.length=0;
   //   this.adminMenu.length=0;
   //   if (this.menuItems!= undefined && this.menuItems.length >0)
   //   {
   //     for (var i = 0; i < this.menuItems.length; ++i) {
   //         let item = this.menuItems[i];
   //         if (item.parent=='apps')
   //           this.appMenu.push(item);
   //         if (item.parent=='admin')
   //           this.adminMenu.push(item);
   //     }
   //   }
   // }

private updateOrgInfo()
{
      this.orgInfo  = JSON.parse(this.commonService.getValueFromStore("orgInfo"));

      if (this.orgInfo != undefined && this.orgInfo != null)
      {
          this.headerIcon = this.orgInfo.headerPath;
          this.headerText = this.orgInfo.headerText;
          this.subHeaderText = this.orgInfo.subHeaderText;
      }else 
      {
          this.headerIcon = './assets/title.png';
          this.headerText = 'Water AMR';
          this.subHeaderText = 'Enzen Global Solutions';
      }

}
  private processMessage()
  {
    if (this.messege.key=="loggedIn"){
      this.commonService.putObjectIntoStore("user", this.messege.value);   
      this.user = this.commonService.getObjectFromStore<User>("user");
      //this.menuItems = JSON.parse(this.commonService.getValueFromStore("menuItems"));
      this.menuTree =  JSON.parse(this.commonService.getValueFromStore("menuTree"));
      //this.parseMenuItems();
      this.updateOrgInfo();  
      this.isLoggedin = true;

      //this.router.navigate(['/home']);
    }
    if (this.messege.key=="error440")
    {   this.clearLogin();
        this.router.navigate(['/missing', {msg :"Session Expired"} ]);
        return;
    }
    if (this.messege.key=="Exception"){
      if (this.messege.value !=  null )
      {
        if (this.messege.value.hasOwnProperty("message"))
        {
          let val = this.messege.value.message;
          if (val.indexOf('440')>0)
              {
                this.clearLogin();
                this.router.navigate(['/missing', {msg :"Session Expired"} ]);
                return;
          }

        }
      }
      this.commonService.showError(this.messege.value);
        // this.exceptionMsg = this.messege.value;
        // setTimeout(function (){
        //   //#exceptionDiv.hide();
        //   this.exceptionMsg=undefined;
        // }.bind(this),1000*5)
//      alert("An Exception occured" + this.messege.value);

    }
     if (this.messege.key=="loadingStart"){
       this.isloading = true;
     }
      if (this.messege.key=="loadingStop"){
        this.isloading=false;
      }

  }

}
