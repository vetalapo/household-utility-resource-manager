import { Guid } from "ayax-common-types";

export class AdvertResponsibilityModel {
  userId: number;
  comment: string;
  divisionId: number;
  id: Guid;
  ids: Guid[] = [];
  constructor(init?: Partial<AdvertResponsibilityModel>) {
    if (init) {
      Object.assign(this, init);
    }
  }
}
