import { ApiUserResponse } from './api-user-response';

export interface ApiTokenResponse {
  token: string;
  user: ApiUserResponse;
  statusCode: number;
}
