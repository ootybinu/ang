import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { KeyValue } from '../../../models/common/common';
import { UserConsumptionSearch } from '../../../models/realtime/user-consumption-search';
import { UserConsumptionSearchResponse } from '../../../models/realtime/user-consumption-search-response';

@Component({
  selector: 'app-realtime-search',
  templateUrl: './realtime-search.component.html',
  styleUrls: ['./realtime-search.component.scss']
})
export class RealtimeSearchComponent implements OnInit {
	private _search:UserConsumptionSearch;
	public selectedLocation;
	userSelected:UserConsumptionSearchResponse;
	ActiveModal:NgbActiveModal;

	@Input('search')
	set search(value:UserConsumptionSearch)
	{
		this.userSelected = value.initial;
		this._search = value;

	}
	get search():UserConsumptionSearch
	{
		return this._search;
	}

  constructor( private activeModal:NgbActiveModal) { 
this.ActiveModal = activeModal;
  }

  ngOnInit() {
  }
  close()
  {
  	this.activeModal.close(this.userSelected);
  }

  locationchange(evt)
  {
  	let val = evt.target.value;
  	let result = this.search.Organization.filter(function (ob){return ob.key == val});
  	if (result.length >0)
  	{
  		this.selectedLocation = result[0].value;
  		this.userSelected.OrganizationText = result[0].value;
  	}
  }
 
}
