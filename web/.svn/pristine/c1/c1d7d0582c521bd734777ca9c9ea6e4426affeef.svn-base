import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';

import { environment } from '../../../environments/environment';
import { CommonService} from './common.service';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HttpClientService {

  constructor(private http:Http, private commonService:CommonService) { }

 	private setHeaders():Headers {
     let key = sessionStorage.getItem("key") || "";

 		let headerConfig ={
 			'Content-Type':'application/json', 
 			'Accept':'application/json', 
       'Autherization': key
 		};

 		return new Headers(headerConfig);
 	}

 	formatErrors(error:any){
     //this.commonService.publish("loadingStop");
     if (error != undefined && error != null && error.status != null){
       if (error.status == 440)
       {
         this.commonService.publish ("error440");
         return Observable.throw(new Error("Session Expired"));
         //return null;
        //this.router.navigate(['/missing', {msg :"Session Timed Out, Please logout and Login again "}]);
      }
       else 
         return Observable.throw(new Error(error));
     }
     else 
      return Observable.throw(new Error(error)); 
// 		return Observable.throw(new Error(error));
 	}

 	post(path: string, body: Object = {}): Observable<any> {
     this.commonService.publish("loadingStart");
    return this.http.post(
      `${environment.api_url}${path}`,
      JSON.stringify(body),
      { headers: this.setHeaders() }
    )
    .catch((err)=>this.formatErrors(err))
    .map((res:Response) => res.json())
    .finally(()=>this.commonService.publish("loadingStop"));
  }

  postfree(path:string, body):Observable<any>{
	let header = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
  	return this.http.post(`${environment.api_url}${path}`, body, { headers : header })
  	.catch(this.formatErrors)
  	.map(res=>res.json());

  }

}
