import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { PaymentService } from '../../shared/payment.service';
import { TitleComponent } from '../../common/tools/title/title.component';

@Component({
  selector: 'app-paymentauthentication',
  templateUrl: './paymentauthentication.component.html',
  styleUrls: ['./paymentauthentication.component.scss']
})
export class PaymentauthenticationComponent implements OnInit {
	selectedDate;
	data;
    authenticated;
   constructor(private commonService:CommonService, private dataService:PaymentService) { }

  ngOnInit() {
  	let date = new Date();
  	this.selectedDate= date.toISOString().slice(0,10);

  }
  getData()
  {
  	this.dataService.getBilledData(this.selectedDate).subscribe(res=> {
		this.data = res;
		this.authenticated =  (this.data != null) ? this.data.authenticated :false;
		}, 
	err=> {
		console.log('Error occured '+ err);
		this.commonService.showError(err);	
	}, 
	()=>{ });
  }
  authenticate()
  {
		this.dataService.authenticate(this.selectedDate).subscribe(res=> {
			//this.paymentvm = res;
			let  result = 	JSON.parse(res);
	 		 if (result.msg=="Success")
                this.commonService.showSuccess("Payment Authenticated")  ;
	          else
                this.commonService.showError(result.msg) ; 
		this.getData();		

		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
  }


}
