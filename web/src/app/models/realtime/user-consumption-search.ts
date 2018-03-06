import { KeyValue } from '../common/common';
import { MasterData} from '../common/master-data';
import  { UserConsumptionSearchResponse } from './user-consumption-search-response';

export class UserConsumptionSearch{
	Organization:KeyValue<number>[];
	RRNumbers:KeyValue<string>[];
	OEM:MasterData[];
	initial:UserConsumptionSearchResponse;
}

