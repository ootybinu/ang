import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { KeyValuePair } from '../../models/common/common';


@Injectable()
export class MessengerService {

	private messengerSource = new Subject<KeyValuePair<any>>();

	messenger = this.messengerSource.asObservable();

	publish(value:KeyValuePair<any>)
	{
		this.messengerSource.next(value);
	}

  constructor() { }
}
