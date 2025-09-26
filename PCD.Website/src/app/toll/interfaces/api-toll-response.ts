export interface ApiTollResponse {
  country: string;
  currency: string;
  emissionsClass: string;
  emissionsClassCode: string;
  exempt: boolean;
  issueDate: string;
  issueDateFormated: string;
  licensePlateNumber: string;
  price: number;
  status: string;
  statusBoolean: boolean;
  validityDateFrom: string;
  validityDateFromFormated: string;
  validityDateTo: string;
  validityDateToFormated: string;
  vehicleClass: string;
  vehicleClassCode: string;
  vehicleType: string;
  vehicleTypeCode: string;
  vignetteNumber: string;
  whitelist: string;
}
