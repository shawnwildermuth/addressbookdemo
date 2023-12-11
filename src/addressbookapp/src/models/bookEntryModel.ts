import { AddressModel } from "./addressModel";

export interface BookEntryModel {
  id: number;
  companyName: string | null;
  firstName: string | null;
  middleName: string | null;
  lastName: string | null;
  dateOfBirth: string;
  gender: string | null;
  homePhone: string | null;
  workPhone: string | null;
  cellPhone: string | null;
  email: string | null;
  addresses: AddressModel[];
}