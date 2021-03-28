import { IBazaEstate } from "./IBazaEstate";
import { IBazaBlacklistEstates } from "./IBazaBlacklistEstates";
import { IBazaContact } from "./IBazaContact";

export interface IBazaDuplicateResponse {
    Uid: string;
    Estates: IBazaEstate[];
    BlacklistEstates: IBazaBlacklistEstates[];
    Contacts: IBazaContact[];
}