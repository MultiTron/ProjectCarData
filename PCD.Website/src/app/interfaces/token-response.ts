import { UserResponse } from "./user-response";

export interface TokenResponse {
  token: string;
  user: UserResponse;
  statusCode: number;
}
