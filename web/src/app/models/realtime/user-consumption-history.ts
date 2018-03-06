export class UserConsumptionHistory{
	unitId:string ;
    date:string;
    time:string;
    consumptionInMCube :number;
    batteryVoltage :number;
    oemName :string;
    dayConsumption:number;
}

export class UserConsumptionHistoryInput {
	unitid:number;
	role:number;
}