import { ApiCarResponse } from './api-car-response';

export interface ApiCarsResponse {
  content: ApiCarResponse[];
  statusCode: number;
}
