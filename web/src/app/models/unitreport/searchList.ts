import { KeyValue } from '../common/common';

export class searchList{
	Divisions:KeyValue<number>;
	OEM:KeyValue<string>;
	Meter:KeyValue<string>;

}
export class subitem {
	parentId:number;
	typeId:number;
}
export class searchResult {
	meterType:string;
	oEM:string;
	division:number;
	subDivision:number;
	service:number;
	location:number;
	consumer:number;
	fromDate:string;
	toDate:string;
}
