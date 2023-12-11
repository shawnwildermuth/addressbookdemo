export interface AddressModel {
  id: number;
  name: string | null;
  line1: string | null;
  line2: string | null;
  line3: string | null;
  cityTown: string | null;
  stateProvince: string | null;
  postalCode: string | null;
  country: string | null;
}