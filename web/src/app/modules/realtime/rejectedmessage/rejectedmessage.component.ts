import { Component, OnInit } from '@angular/core';
import { CommonService} from '../../shared/common.service';
import { RealtimeService } from '../../shared/realtime.service';
import { TitleComponent } from '../../common/tools/title/title.component';
import {KeyValue}  from '../../../models/common/common';
import {messageInput}  from '../../../models/realtime/messageInput';

import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 

@Component({
  selector: 'app-rejectedmessage',
  templateUrl: './rejectedmessage.component.html',
  styleUrls: ['./rejectedmessage.component.scss']
})
export class RejectedmessageComponent implements OnInit {
	pagedInput:PagedData<messageInput> = new PagedData<messageInput>();
	totalpages:number=10;
	msgs=[];
  	constructor(private commonService:CommonService, private dataService:RealtimeService) { }

  	ngOnInit() {
  		this.pagedInput.PageNumber = 1;
  		this.pagedInput.NumberOfRecords=20;
  		this.getData();
  	}

	pageChanged(nextPage:number){
	  this.pagedInput.PageNumber=nextPage;
	  this.getData();
	}

	private getData() {
		//this.pagedInput.Data  = search;
		this.dataService.getRejectedMessages(this.pagedInput).subscribe(res=> {
			this.msgs = res.data;
			this.totalpages  =  this.commonService.getTotalPages(res.totalRecords,this.pagedInput.NumberOfRecords);
		}, 
		err=> {
			console.log('Error occured '+ err);
			this.commonService.showError(err);	
		}, 
		()=>{ });
	}
}
