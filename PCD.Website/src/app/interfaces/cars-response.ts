import { CarResponse } from './car-response';

export interface CarsResponse {
  content: CarResponse[];
  statusCode: number;
}
