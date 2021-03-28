import { Guid } from "ayax-common-types";
import { ContactModel } from "../Contact/ContactModel";
import { ProcessingStatusIdModel } from "./ProcessingStatusIdModel";
import { AdvertAddressModel } from "./AdvertAddressModel";

export class AdvertCardModel {
    advertId: number;
    guid: Guid;
    active: boolean;
    title: string;
    exportedActionLink: string;
    parsingDateTime: Date;
    createdDateTime: Date;
    createdUserId: number;
    description: string;
    price: number;
    roomsAmount: number;
    objectFloor: number;
    houseAmountFloors: number;
    objectSquare: number;
    objectLandSquare: number;
    objectRaion: string;
    objectAddress: string;
    houseMaterialType: string;
    latitude: number;
    longitude: number;
    livingArea: number;
    kitchenArea: number;
    facade:number;
    propertyCategoryId: number;
    propertySubCategoryId: number;
    publisherTypeId: number;
    advertCategoryId: number;
    overallConditionId: number;
    certificateId: number;
    wallId: number;
    gasSupplyId: number;
    waterSupplyId: number;
    electricitySupplyId: number;
    sewerageId: number;
    houseFundId: number;
    conveniencesId: number;
    processing: {
        lastChangedDateTime: Date;
        setByUserId: number;
        setToUserId: number;
        processedByUserId: number;
        processingStatusId: ProcessingStatusIdModel;
        processingStatusTitle: string;
        processedStatusId: number;
        processedStatusIsExportable:boolean
    };
    export: {
        status: boolean;
        userId: number;
        actionDateTime: Date;
        destinationIdentity: string;
        exportSystemId: number;
        exportSystem: string;
    } = { status: null, userId: null, actionDateTime: null, exportSystemId: null, exportSystem: null, destinationIdentity: null };
    origins: Array<{
        uri: string;
        sourceId: number;
        source: string;
    }>;
    advertActionHistory: Array<{
        actionDateTime: Date;
        createdUserId: number;
        changeSummary: string;
        advertActionHistoryTypeId: number;
        advertActionHistoryType: string;
    }>;
    contacts: ContactModel[];
    pictures: string[];
    comments: Array<{
        id: number;
        text: string;
        createdUserId: number;
        createdDateTime: Date;
        lastChangedDateTime: Date;
    }>;
    address: AdvertAddressModel;
    constructor(init?: Partial<AdvertCardModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
