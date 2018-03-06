import { Component, OnInit ,OnDestroy} from '@angular/core';
import { ActivatedRoute} from '@angular/router';
import { CommonService} from '../../shared/common.service';
import { GprsdataService } from '../../shared/gprsdata.service';
import { PagedData} from '../../../models/common/pageddata';
import { PagedResponse} from '../../../models/common/pagedresponse';
import { PaginationComponent } from '../../common/tools/pagination/pagination.component'; 
import { TitleComponent } from '../../common/tools/title/title.component';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
	id:any;
	historyRows:any=[];
	private sub:any;

  	constructor(private dataService:GprsdataService, private route:ActivatedRoute, private commonService:CommonService) { }

  	ngOnInit() {
 	
 	this.sub = this.route.params.subscribe(t=>
 			{
 				this.id = t['id'];
 				this.getData();

 			});


 	 }	
  	
  	ngOnDestroy(){
  		this.sub.unsubscribe();
  	}
  	private getData()
  	{
  		this.dataService.getGprsHistory(this.id).subscribe(res=> {
			this.historyRows = res;
		}, 
		err=> {
          console.log('Error occured '+ err);
          this.commonService.showError(err);  
          }, 
		()=>{ });
  	}
}
