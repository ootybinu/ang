import {KeyValuePair} from '../common/common';
export class Unit 
{
	id:number;
	unitid:string;
	installon:date;
	pipesize:string;
	pipesizenew:string;
	totalflow:number;
	averageflow:number;
	subdivisionid:number;
	divisionid:number;
	servicestnid:number;
	locationid:number;
	divisionhead:string;
	subdivisionhead:string;
	messagetime:date;
	mobilenumberofunit:string;
	metercalibfactor:number;
	metercalibrationdate:date;
	batterylimitvalue:string;
	initialmeterreading:number;
	considerinitmtrfornextsms:boolean;
	ltrperpulse:number;
	fieldpicture:string;
	tariffperltr:number;
	mobilenumberofalarmmessagerecipient1:string;
	mobilenumberofalarmmessagerecipient2:string;
	mobilenumberofalarmmessagerecipient3:string;
	mailidofalarmmessagerecipient1:string;
	mailidofalarmmessagerecipient2:string;
	mailidofalarmmessagerecipient3:string;
	latitude:number;
	longitude:number;
	consumerid:number;
	consumeraddress:string;
	consumercontactnumber:string;
	meterslno:string;
	oemname:string;
	metertype:string;
	meterflowtype:string;
	meterbillingtype:string;
	gsmsignalstrength:string;
	metermodelnumber:string;
	modeofcommuniction:string;
	gprstype:string;
	gprstypeurl:string;
	communicationperiod:string;
	rechargedate:date;
	serviceprovider:string;
	daysofwaterflow:string;
	fromwaterflow:string;
	towaterflow:string;
	averagepressure:number;
	averageflowrate:number;
	active:boolean;
	billgroupid:number;
}

export class SelectionLists
{
	OEMNames:KeyValuePair<string>; 
	MeterTypes :KeyValuePair<string>;
	FlowTypes :KeyValuePair<string>;
	MeterBillingTypes :KeyValuePair<string>;
	MobileServiceProviders :KeyValuePair<string>;
	WeekNames :KeyValuePair<string>;
	CommModes :KeyValuePair<string>;
	DivisionHeads :KeyValuePair<string>;
	SubDivisionHeads :KeyValuePair<string>;
	ConsumerNames :KeyValuePair<string>;
	Divisions :KeyValuePair<number>;
	SubDivisions :KeyValuePair<number>;
	ServiceStations:KeyValuePair<number>;
	Locations:KeyValuePair<number>;
	BillGroups:KeyValuePair<number>;
}
export class subitem {
	parentId:number;
	typeId:number;
}
export class UnitSearch
{
	MobileNumber:string;
}