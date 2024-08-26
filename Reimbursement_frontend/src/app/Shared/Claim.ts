import { DecimalPipe } from "@angular/common";

export interface Claim{
    id? : Number,
    date : Date,
    typeId : Number,
    typeName : string,
    requestedValue: DecimalPipe,
    approvedValue: DecimalPipe | undefined,
    currencyId: Number,
    currencyName : string,
    proccessed: Boolean,
    approved: Boolean,
    approvedBy? : string,
    approveNote? :string, 
    creator: string,
    image: string
}