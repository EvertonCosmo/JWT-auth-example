export interface LoginPayload {
  cpf: string;
  password: string;
}
export interface UserModel {
  cpf: string;
  password: string;
}
// export interface Login {
//   id?: number;
//   email: string;
//   profiles: Array<string>;
// }
export interface UserPayload {
  id?: number;
  cpf: string;
  name: string;
  lastName: string;
}
export interface UserResponse {
  user: UserPayload;
  token: string;
}
export type User = UserModel | UserPayload;
